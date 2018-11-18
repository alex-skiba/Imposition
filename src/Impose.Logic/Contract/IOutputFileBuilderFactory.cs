using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Engines;

namespace Albelli.Impose.Logic.Contract
{
    public interface IOutputFileBuilderFactory
    {
        IOutputFileBuilder Get(Layout layout, Imposition imposition);
    }
}