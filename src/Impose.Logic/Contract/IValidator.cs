using System.Collections.Generic;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Contract
{
    /// <summary>
    ///     Validates everything.
    /// </summary>
    public interface IValidator
    {
        // todo: ValidationResult
        void ValidateLayout(Layout layout);
        void ValidateSourceFiles(List<SourceFile> sourceFiles, Layout layout, Imposition imposition);
    }
}