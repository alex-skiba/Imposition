using System.Collections.Generic;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.XpressoAdapter
{
    public static class Pap402ImpositionGenerator
    {
        public static Imposition Generate()
        {
            return new Imposition
            {
                Key = "pap_402_imposition",
                PapCode = 402,
                PrintSurfaceType = PrintSurface.DuplexFlipX,
                SourcePagesImpositionOrder = SourcePagesImpositionOrder.Reversed,
                ImpositionDirection = SheetImpositionDirection.Up,
                ImpositionStartPoint = SheetImpositionStartPoint.BottomRight,
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