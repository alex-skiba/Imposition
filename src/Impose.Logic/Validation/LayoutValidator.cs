using System.Linq;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Input;
using FluentValidation;

namespace Albelli.Impose.Logic.Validation
{
    internal class LayoutValidator : AbstractValidator<Layout>
    {
        public LayoutValidator(Size validCutBoxSize, Size validMediaBoxSize)
        {
            RuleForEach(l => l.Tiles.Select(t => t.CutBox.Size))
                .Must(s => s.EqualTo(validCutBoxSize))
                .OverridePropertyName("Tile.CutBox.Size")
                .WithMessage("All tiles must have the same CutBox size!");
            RuleForEach(l => l.Tiles.Select(t => t.MediaBox.Size))
                .Must(s => s.EqualTo(validMediaBoxSize))
                .OverridePropertyName("Tile.MediaBox.Size")
                .WithMessage("All tiles must have the same MediaBox size!");
        }
    }
}