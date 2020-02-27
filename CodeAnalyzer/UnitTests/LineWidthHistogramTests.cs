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
        public const string TEST_STRING_3 = "blah";
        public const string TEST_STRING_4 = "and here we go again";
        public const string TEST_STRING_5 = "five it";

        private LineWidthHistogram Histogram;

        [Test]
        public void LineWidthHistogramLineCountShouldBeZeroOnInit()
        {
            Assert.That(Histogram.LineCount, Is.Zero);
        }

        [Test]
        public void LineWidthHistogramLineWidthsShouldBeEmpty()
        {
            Assert.That(Histogram.LineWidths, Is.Empty);
        }

        [Test]
        public void LineWidthHistogramWidestLineShouldBeZero()
        {
            Assert.That(Histogram.WidestLine, Is.Zero);
        }

        [Test]
        public void AddLineShouldIncreaseLineCountByOne()
        {
            Histogram.AddLine(TEST_STRING_1);
            Assert.That(Histogram.LineCount, Is.EqualTo(1));
        }
        
        [Test]
        public void AddLineShouldIncreaseLineWidthsCount()
        {
            Histogram.AddLine(TEST_STRING_1);
            Assert.That(Histogram.LineWidths.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddLienShouldAddLineWithValueTEST_STRING_1()
        {
            Histogram.AddLine(TEST_STRING_1);
            Assert.That(Histogram.LineWidths[TEST_STRING_1.Length], Is.EqualTo(1));
        }

        [Test]
        public void AddLine_Should_CreateHistogram()
        {
            Histogram
                .AddLine(TEST_STRING_1)
                .AddLine(TEST_STRING_2);

            Assert.That(Histogram.LineWidths[TEST_STRING_2.Length], Is.EqualTo(1));

            Histogram.AddLine(TEST_STRING_2);

            Assert.That(Histogram.LineWidths[TEST_STRING_2.Length], Is.EqualTo(2));
        }

        [Test]
        public void WidestLine_Should_Return_The_WidestLine()
        {
            Histogram
            .AddLine(TEST_STRING_1)
            .AddLine(TEST_STRING_2);

            Assert.That(Histogram.WidestLine, Is.EqualTo(TEST_STRING_2.Length));
        }

        [Test]
        public void GetLinesForWidth_Should_Throw()
        {
            Assert.That(() => Histogram.GetLineCountForWidth(0), Throws.Exception);
        }

        [Test]
        public void GetLinesForWidth_Should_Return()
        {
            Histogram.AddLine(TEST_STRING_1);

            Assert.That(() => Histogram.GetLineCountForWidth(TEST_STRING_1.Length), Is.EqualTo(1));
        }

        [Test]
        public void GetMedianLineWidth_Should_Return_Seven()
        {
            Histogram
                .AddLine(TEST_STRING_1)
                .AddLine(TEST_STRING_2)
                .AddLine(TEST_STRING_3)
                .AddLine(TEST_STRING_4)
                .AddLine(TEST_STRING_5);

            Assert.That(() => Histogram.GetMedianLineWidth(), Is.EqualTo(7));
        }

        [Test]
        public void Combine_Should_Combine_Histograms()
        {
            Histogram
                .AddLine(TEST_STRING_2)
                .Combine(new LineWidthHistogram().AddLine(TEST_STRING_1));

            Assert.That(Histogram.LineWidths.Count, Is.EqualTo(2));
            Assert.That(Histogram.LineWidths[TEST_STRING_1.Length], Is.EqualTo(1));
            Assert.That(Histogram.LineWidths[TEST_STRING_2.Length], Is.EqualTo(1));
        }
    }
}