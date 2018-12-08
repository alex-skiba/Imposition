using System.Linq;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Contract;

namespace Albelli.Impose.Logic
{
    public class Imposer
    {
        private readonly IOutputFileBuilderFactory _fileBuilderFactory;
        private readonly IImpositionRepository _impositionRepository;
        private readonly ILayoutRepository _layoutRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISourceFilesRepository _sourceFilesRepository;
        private readonly IValidator _validator;

        public Imposer(ILayoutRepository layoutRepository,
            IImpositionRepository impositionRepository,
            ISourceFilesRepository sourceFilesRepository,
            IOutputFileBuilderFactory fileBuilderFactory,
            IPdfGenerator pdfGenerator,
            IValidator validator)
        {
            _layoutRepository = layoutRepository;
            _impositionRepository = impositionRepository;
            _sourceFilesRepository = sourceFilesRepository;
            _fileBuilderFactory = fileBuilderFactory;
            _pdfGenerator = pdfGenerator;
            _validator = validator;
        }

        public string Impose(BatchMetadata batch)
        {
            var layout = _layoutRepository.Get(batch.LayoutKey);
            _validator.ValidateLayout(layout);
            var imposition = _impositionRepository.Get(batch.ImpositionKey);
            var outputFileBuilder = _fileBuilderFactory.Get(layout, imposition);
            var sourceFiles = batch.AlbumIds.Select(albumId => _sourceFilesRepository.Get(albumId)).ToList();
            _validator.ValidateSourceFiles(sourceFiles, layout, imposition);
            var outputFile = outputFileBuilder.Build(sourceFiles);
            var outputPdfFileName = _pdfGenerator.Generate(outputFile);

            return outputPdfFileName;
        }
    }
}