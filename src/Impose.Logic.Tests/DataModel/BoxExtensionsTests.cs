using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Extensions;
using NUnit.Framework;
using Shouldly;

namespace Albelli.Impose.Logic.Tests.DataModel
{
    [TestFixture]
    public class BoxExtensionsTests
    {
        [Test]
        public void GetTranslation_ShouldReturnCorrectTranslation()
        {
            var baseBox = new Box {Left = 0, Bottom = 0, Width = 100, Height = 100};
            var translatedBox = new Box {Left = 10, Bottom = 0, Width = 120, Height = 80};

            var actual = baseBox.GetTranslation(translatedBox);

            actual.LeftOffset.ShouldBe(10);
            actual.BottomOffset.ShouldBe(0);
            actual.RightOffset.ShouldBe(30);
            actual.TopOffset.ShouldBe(-20);
        }

        [Test]
        public void GetTranslated_ShouldReturnCorrectTranslation()
        {
            var baseBox = new Box {Left = 0, Bottom = 0, Width = 100, Height = 100};
            var translation = new BoxTranslation {LeftOffset = 0, BottomOffset = 10, RightOffset = 20, TopOffset = -50};

            var actual = baseBox.GetTranslated(translation);

            actual.Left.ShouldBe(0);
            actual.Bottom.ShouldBe(10);
            actual.Right.ShouldBe(120);
            actual.Top.ShouldBe(50);
            actual.Width.ShouldBe(120);
            actual.Height.ShouldBe(40);
        }

        [Test]
        public void GetCenter_ShouldReturnCorrectPoint()
        {
            var baseBox = new Box {Left = 10, Bottom = 20, Width = 100, Height = 120};

            var actual = baseBox.GetCenter();

            actual.X.ShouldBe(60);
            actual.Y.ShouldBe(80);
        }
    }
}