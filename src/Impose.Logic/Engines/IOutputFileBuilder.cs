using System.Collections.Generic;
using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Engines
{
    public interface IOutputFileBuilder
    {
        OutputFile Build(List<SourceFile> sourceFiles);
    }
}