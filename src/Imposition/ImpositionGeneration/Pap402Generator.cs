using System.Collections.Generic;
using Imposition.Extensions;
using Imposition.Model.V2;

namespace Imposition.ImpositionGeneration
{
    public static class Pap402Generator
    {
        public static ImpositionConfig Generate()
        {
            return new ImpositionConfig
            {
                SourcePagesImpositionOrder = SourcePagesImpositionOrder.Reversed,
                BackDirection = SheetImpositionDirection.Up,
                BackStartPoint = SheetImpositionStartPoint.BottomRight,
                FrontDirection = SheetImpositionDirection.Up,
                FrontStartPoint = SheetImpositionStartPoint.BottomRight,
                MediaBoxSize = new Size {Width = 216f.MmToPoints(), Height = 286f.MmToPoints()},
                MediaRotationAngle = 90f,
                ProductLeaderContent = new List<Element>
                {
                    new Element
                    {
                        Type = ElementType.Text,
                        Key = "{vendorid}.jpg",
                        Location = new Point {X = 31f.MmToPoints(), Y = 44f.MmToPoints()},
                        RotationAngle = 90f
                    }
                }
            };
        }
    }
}