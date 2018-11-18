using System.Linq;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Contract;

namespace Albelli.Impose.Logic
{
    public class Imposer
    {
        private readonly ILayoutRepository _layoutRepository;
        private readonly IImpositionRepository _impositionRepository;
        private readonly ISourceFilesRepository _sourceFilesRepository;
        private readonly IOutputFileBuilderFactory _fileBuilderFactory;
        private readonly IPdfGenerator _pdfGenerator;

        public Imposer(ILayoutRepository layoutRepository,
            IImpositionRepository impositionRepository,
            ISourceFilesRepository sourceFilesRepository,
            IOutputFileBuilderFactory fileBuilderFactory,
            IPdfGenerator pdfGenerator)
        {
            _layoutRepository = layoutRepository;
            _impositionRepository = impositionRepository;
            _sourceFilesRepository = sourceFilesRepository;
            _fileBuilderFactory = fileBuilderFactory;
            _pdfGenerator = pdfGenerator;
        }

        public string Impose(BatchMetadata batch)
        {
            var layout = _layoutRepository.Get(batch.LayoutKey);
            var imposition = _impositionRepository.Get(batch.ImpositionKey);
            var outputFileBuilder = _fileBuilderFactory.Get(layout, imposition);
            var sourceFiles = batch.AlbumIds.Select(albumId => _sourceFilesRepository.Get(albumId)).ToList();
            var outputFile = outputFileBuilder.Build(sourceFiles);
            var outputPdfFileName = _pdfGenerator.Generate(outputFile);

            return outputPdfFileName;
        }
    }
}