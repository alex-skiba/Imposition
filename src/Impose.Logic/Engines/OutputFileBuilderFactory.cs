using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Contract;

namespace Albelli.Impose.Logic.Engines
{
    public class OutputFileBuilderFactory : IOutputFileBuilderFactory
    {
        // only SmartStacker builders are supported yet
        public IOutputFileBuilder Get(Layout layout, Imposition imposition)
        {
            return imposition.IsDuplex
                ? (IOutputFileBuilder) new DuplexSmartStackerOutputFileBuilder(layout, imposition)
                : new SimplexSmartStackerOutputFileBuilder(layout, imposition);
        }
    }
}