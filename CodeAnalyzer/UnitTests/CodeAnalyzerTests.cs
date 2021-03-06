using NUnit.Framework;
using Analyzer;

namespace UnitTests
{
    [TestFixture]
    public class CodeAnalyzerTests
    {
        [Test]
        public void CodeAnalyzer_Should_Throw_ArugmentException_ValidPath()
        {
            Assert.That(() => new CodeAnalyzer(string.Empty),
                Throws.ArgumentException.With.Message.Contains("valid"));
            Assert.That(() => new CodeAnalyzer("   "),
                Throws.ArgumentException.With.Message.Contains("valid"));
        }

        [Test]
        public void CodeAnalyzer_Should_Throw_ArgumentException_NotFound()
        {
            // you should not have a directory with this name...anywhere
            Assert.That(() => new CodeAnalyzer("bladh blahdhdhad"),
                Throws.ArgumentException.With.Message.Contains("not found"));
        }

        [Test]
        public void CodeAnalyzer_Should_Not_Throw_For_ValidPath()
        {
            Assert.That(() => new CodeAnalyzer("."), Throws.Nothing);
        }
    }
}