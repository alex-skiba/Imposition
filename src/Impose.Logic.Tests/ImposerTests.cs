using System.Collections.Generic;
using System.Linq;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;
using Albelli.Impose.Logic.Engines;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Albelli.Impose.Logic.Tests
{
    [TestFixture]
    public class ImposerTests
    {
        [Test]
        public void Impose_ShouldCallDependenciesCorrectly()
        {
            // Arrange
            var layoutKey = "test_layout";
            var impositionKey = "test_imposition";
            var albumIds = new List<int> {1};
            var layout = new Layout();
            var imposition = new Imposition();
            var sourceFile = new SourceFile();
            var outputFile = new OutputFile();
            var outputPdfName = "test.pdf";
            var layoutRepositoryMock = Substitute.For<ILayoutRepository>();
            var impositionRepositoryMock = Substitute.For<IImpositionRepository>();
            var sourceFilesRepositoryMock = Substitute.For<ISourceFilesRepository>();
            var outputFileBuilderFactoryMock = Substitute.For<IOutputFileBuilderFactory>();
            var outputFileBuilderMock = Substitute.For<IOutputFileBuilder>();
            var pdfGeneratorMock = Substitute.For<IPdfGenerator>();
            var validatorMock = Substitute.For<IValidator>();

            layoutRepositoryMock.Get(Arg.Any<string>()).Returns(layout);
            impositionRepositoryMock.Get(Arg.Any<string>()).Returns(imposition);
            sourceFilesRepositoryMock.Get(Arg.Any<int>()).Returns(sourceFile);
            outputFileBuilderFactoryMock.Get(Arg.Any<Layout>(), Arg.Any<Imposition>()).Returns(outputFileBuilderMock);
            outputFileBuilderMock.Build(Arg.Any<List<SourceFile>>()).Returns(outputFile);
            pdfGeneratorMock.Generate(Arg.Any<OutputFile>()).Returns(outputPdfName);

            var target = new Imposer(layoutRepositoryMock, impositionRepositoryMock, sourceFilesRepositoryMock, outputFileBuilderFactoryMock, pdfGeneratorMock, validatorMock);

            // Act
            target.Impose(new BatchMetadata {ImpositionKey = impositionKey, LayoutKey = layoutKey, AlbumIds = albumIds});

            //Assert
            layoutRepositoryMock.Received(1).Get(layoutKey);
            validatorMock.Received(1).ValidateLayout(layout);
            impositionRepositoryMock.Received(1).Get(impositionKey);
            sourceFilesRepositoryMock.Received(1).Get(albumIds[0]);
            validatorMock.Received(1).ValidateSourceFiles(Arg.Is<List<SourceFile>>(files => files.Contains(sourceFile)), layout, imposition);
            outputFileBuilderFactoryMock.Received(1).Get(layout, imposition);
            outputFileBuilderMock.Received(1).Build(Arg.Is<List<SourceFile>>(list => list.Single() == sourceFile));
            pdfGeneratorMock.Received(1).Generate(outputFile);
        }

        [Test]
        public void Impose_ShouldProcessAlbumsCorrectly()
        {
            // Arrange
            var fakeAlbumIds = new List<int> {1, 2, 3};
            var fakeAlbums = fakeAlbumIds.Select(albumId => new {AlbumId = albumId, SourceFile = new SourceFile {FileName = $"source_file_{albumId}"}}).ToList();
            var expectedSourceFiles = new List<SourceFile> {fakeAlbums[0].SourceFile, fakeAlbums[1].SourceFile, fakeAlbums[2].SourceFile};

            var layoutRepositoryMock = Substitute.For<ILayoutRepository>();
            var impositionRepositoryMock = Substitute.For<IImpositionRepository>();
            var sourceFilesRepositoryMock = Substitute.For<ISourceFilesRepository>();
            var outputFileBuilderFactoryMock = Substitute.For<IOutputFileBuilderFactory>();
            var outputFileBuilderMock = Substitute.For<IOutputFileBuilder>();
            var pdfGeneratorMock = Substitute.For<IPdfGenerator>();
            var validatorMock = Substitute.For<IValidator>();

            sourceFilesRepositoryMock.Get(1).Returns(fakeAlbums[0].SourceFile);
            sourceFilesRepositoryMock.Get(2).Returns(fakeAlbums[1].SourceFile);
            sourceFilesRepositoryMock.Get(3).Returns(fakeAlbums[2].SourceFile);
            outputFileBuilderFactoryMock.Get(Arg.Any<Layout>(), Arg.Any<Imposition>()).Returns(outputFileBuilderMock);
            var actualSourceFiles = new List<SourceFile>();
            outputFileBuilderMock.Build(Arg.Do<List<SourceFile>>(sourceFiles => actualSourceFiles.AddRange(sourceFiles)));

            var target = new Imposer(layoutRepositoryMock, impositionRepositoryMock, sourceFilesRepositoryMock, outputFileBuilderFactoryMock, pdfGeneratorMock, validatorMock);

            // Act
            target.Impose(new BatchMetadata {AlbumIds = fakeAlbumIds});

            //Assert
            sourceFilesRepositoryMock.Received(1).Get(1);
            sourceFilesRepositoryMock.Received(1).Get(2);
            sourceFilesRepositoryMock.Received(1).Get(3);
            actualSourceFiles.ShouldBe(expectedSourceFiles);
        }
    }
}