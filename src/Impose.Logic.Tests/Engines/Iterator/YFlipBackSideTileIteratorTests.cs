using Albelli.Impose.Logic.Engines.Iterator;
using NUnit.Framework;
using Shouldly;

namespace Albelli.Impose.Logic.Tests.Engines.Iterator
{
    [TestFixture]
    public class YFlipBackSideTileIteratorTests
    {
        [Test]
        public void BackSequence_2x2()
        {
            var target = new YFlipBackSideTileIterator(2, 2);

            target.CurrentBackPosition.RowIndex.ShouldBe(1);
            target.CurrentBackPosition.ColumnIndex.ShouldBe(0);

            target.MoveForward();
            target.CurrentBackPosition.RowIndex.ShouldBe(0);
            target.CurrentBackPosition.ColumnIndex.ShouldBe(0);

            target.MoveForward();
            target.CurrentBackPosition.RowIndex.ShouldBe(1);
            target.CurrentBackPosition.ColumnIndex.ShouldBe(1);

            target.MoveForward();
            target.CurrentBackPosition.RowIndex.ShouldBe(0);
            target.CurrentBackPosition.ColumnIndex.ShouldBe(1);

            target.MoveForward();
            target.CurrentBackPosition.RowIndex.ShouldBe(1);
            target.CurrentBackPosition.ColumnIndex.ShouldBe(0);
        }

        [Test]
        public void FrontSequence_2x2()
        {
            var target = new YFlipBackSideTileIterator(2, 2);

            target.IsInitial.ShouldBeTrue();
            target.CurrentFrontPosition.RowIndex.ShouldBe(0);
            target.CurrentFrontPosition.ColumnIndex.ShouldBe(0);

            target.MoveForward();
            target.IsInitial.ShouldBeFalse();
            target.CurrentFrontPosition.RowIndex.ShouldBe(1);
            target.CurrentFrontPosition.ColumnIndex.ShouldBe(0);

            target.MoveForward();
            target.CurrentFrontPosition.RowIndex.ShouldBe(0);
            target.CurrentFrontPosition.ColumnIndex.ShouldBe(1);

            target.MoveForward();
            target.CurrentFrontPosition.RowIndex.ShouldBe(1);
            target.CurrentFrontPosition.ColumnIndex.ShouldBe(1);

            target.MoveForward();
            target.IsInitial.ShouldBeTrue();
            target.CurrentFrontPosition.RowIndex.ShouldBe(0);
            target.CurrentFrontPosition.ColumnIndex.ShouldBe(0);
        }

        [Test]
        public void Initial_2x2()
        {
            var target = new YFlipBackSideTileIterator(2, 2);

            target.IsInitial.ShouldBeTrue();
            target.InitialFrontPosition.RowIndex.ShouldBe(0);
            target.InitialFrontPosition.ColumnIndex.ShouldBe(0);
        }
    }
}