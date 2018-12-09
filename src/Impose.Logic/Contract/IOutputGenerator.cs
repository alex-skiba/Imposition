using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Contract
{
    public interface IOutputGenerator
    {
        /// <summary>
        /// Processes specified model into a file (pdf, jdf, svg etc.)
        /// </summary>
        /// <param name="outputFile">Output file model</param>
        /// <returns>Path to the generated file</returns>
        string Generate(OutputFile outputFile);
    }
}