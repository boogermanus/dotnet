using NUnit.Framework;
using Analyzer;

namespace UnitTests
{
    [TestFixture]
    public class LineWidthHistogramTests
    {
        public const string TEST_STRING_1 = "testing";
        public const string TEST_STRING_2 = "testing again";
        [Test]
        public void LineWidthHistogram_Should_Init()
        {
            var histo = new LineWidthHistogram();

            Assert.That(histo.LineCount, Is.Zero);
            Assert.That(histo.LineWidths, Is.Empty);
        }

        [Test]
        public void AddLine_Should_AddTo_Dict_And_Increase_LineCount()
        {
            var histo = new LineWidthHistogram();

            histo.AddLine(TEST_STRING_1);

            Assert.That(histo.LineCount, Is.EqualTo(1));
            Assert.That(histo.LineWidths.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddLine_Should_CreateHistogram()
        {
            var histo = new LineWidthHistogram();

            histo.AddLine(TEST_STRING_1);
            histo.AddLine(TEST_STRING_2);

            Assert.That(histo.LineWidths[TEST_STRING_1.Length], Is.EqualTo(1));
            Assert.That(histo.LineWidths[TEST_STRING_2.Length], Is.EqualTo(1));
        }
    }
}