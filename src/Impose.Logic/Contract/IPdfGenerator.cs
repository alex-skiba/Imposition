using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Contract
{
    public interface IPdfGenerator
    {
        string Generate(OutputFile outputFile);
    }
}