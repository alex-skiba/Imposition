using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Contract
{
    public interface ISourceFilesRepository
    {
        SourceFile Get(int albumId);
    }
}