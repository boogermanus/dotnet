using NUnit.Framework;
using Analyzer;

namespace UnitTests
{
    [TestFixture]
    public class LineWidthHistogramTests
    {
        [SetUp]
        public void SetUp()
        {
            Histogram = new LineWidthHistogram();
        }

        [TearDown]
        public void TearDown()
        {
            Histogram = new LineWidthHistogram();
        }
        public const string TEST_STRING_1 = "testing";
        public const string TEST_STRING_2 = "testing again";

        private LineWidthHistogram Histogram;

        [Test]
        public void LineWidthHistogram_Should_Init()
        {
            Assert.That(Histogram.LineCount, Is.Zero);
            Assert.That(Histogram.LineWidths, Is.Empty);

            Assert.That(Histogram.WidestLine, Is.Zero);
        }

        [Test]
        public void AddLine_Should_AddTo_Dict_And_Increase_LineCount()
        {
            Histogram.AddLine(TEST_STRING_1);

            Assert.That(Histogram.LineCount, Is.EqualTo(1));
            Assert.That(Histogram.LineWidths.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddLine_Should_CreateHistogram()
        {
            Histogram.AddLine(TEST_STRING_1);
            Histogram.AddLine(TEST_STRING_2);

            Assert.That(Histogram.LineWidths[TEST_STRING_1.Length], Is.EqualTo(1));
            Assert.That(Histogram.LineWidths[TEST_STRING_2.Length], Is.EqualTo(1));

            Histogram.AddLine(TEST_STRING_2);

            Assert.That(Histogram.LineWidths[TEST_STRING_2.Length], Is.EqualTo(2));
        }

        [Test]
        public void WidestLine_Should_Return_The_WidestLine()
        {
            Histogram.AddLine(TEST_STRING_1);
            Histogram.AddLine(TEST_STRING_2);

            Assert.That(Histogram.WidestLine, Is.EqualTo(TEST_STRING_2.Length));
        }

        [Test]
        public void GetLinesForWidth_Should_Throw()
        {
            Assert.That(() => Histogram.GetLinesForWidth(0), Throws.Exception);
        }

        [Test]
        public void GetLinesForWidth_Should_Return()
        {
            Histogram.AddLine(TEST_STRING_1);

            Assert.That(() => Histogram.GetLinesForWidth(TEST_STRING_1.Length), Is.EqualTo(1));
        }
    }
}