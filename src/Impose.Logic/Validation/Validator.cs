using System;
using System.Collections.Generic;
using System.Linq;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;

namespace Albelli.Impose.Logic.Validation
{
    public class Validator : IValidator
    {
        public void ValidateLayout(Layout layout)
        {
            var defaultMediaBoxSize = layout.Tiles.First().MediaBox.Size;
            var defaultCutBoxSize = layout.Tiles.First().CutBox.Size;

            var validationResult = new LayoutValidator(defaultCutBoxSize, defaultMediaBoxSize).Validate(layout);

            if (!validationResult.IsValid)
            {
                throw new ApplicationException(validationResult.ToString(Environment.NewLine));
            }
        }

        public void ValidateSourceFiles(List<SourceFile> sourceFiles, Layout layout, Imposition imposition)
        {
            var cropBoxComparisonTolerance = 0.01f;
            var rotationAngleComparisonTolerance = 0.01f;
            var layoutCutBoxSize = layout.Tiles.First().CutBox.Size;
            Size expectedSourcePageCropBoxSize;

            if (Math.Abs(imposition.MediaRotationAngle) <= rotationAngleComparisonTolerance || Math.Abs(imposition.MediaRotationAngle - 180.0f) <= rotationAngleComparisonTolerance)
            {
                // orientation of the source file page and layout tile match
                expectedSourcePageCropBoxSize = layoutCutBoxSize;
            }
            else
            {
                // orientation of the source file page and layout tile doesn't match
                expectedSourcePageCropBoxSize = new Size {Width = layoutCutBoxSize.Height, Height = layoutCutBoxSize.Width};
            }

            var validator = new SourceFileValidator(expectedSourcePageCropBoxSize, cropBoxComparisonTolerance);
            var failedValidationResults = sourceFiles.Select(f => validator.Validate(f)).Where(r => !r.IsValid).ToList();

            if (failedValidationResults.Count > 0)
            {
                var errorMessage = string.Join(Environment.NewLine, failedValidationResults.Select(r => r.ToString()));
                throw new ApplicationException(errorMessage);
            }
        }
    }
}