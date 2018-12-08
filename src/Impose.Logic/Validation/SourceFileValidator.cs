using System.Linq;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Output;
using FluentValidation;

namespace Albelli.Impose.Logic.Validation
{
    internal class SourceFileValidator : AbstractValidator<SourceFile>
    {
        public SourceFileValidator(Size validCropBoxSize, float sizeComparisonTolerance)
        {
            RuleForEach(f => f.Pages.Select(p => p.CropBox.Size))
                .Must(s => s.EqualTo(validCropBoxSize, sizeComparisonTolerance))
                .OverridePropertyName("Page.CropBox.Size")
                .WithMessage("Each page of the source file must have crop box of the same size as layout's cut box!");
        }
    }
}