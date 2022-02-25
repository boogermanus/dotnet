using System;
using System.Linq;
using AssertYourself;
using NUnit.Framework;

namespace AssertYourselfTests
{
    [TestFixture]
    public class AutoPayProcessorThingyTests
    {
        [Test]
        public void ProcessDraftOnDueDateShouldDoSomeStuffBadTest()
        {
            var processor = new AutoPayProcessorThingy(new[]
            {
                new AutoPay(AutoPayType.DraftOnDueDate, true, 1)
            });

            var result = processor.ProcessDraftOnDueDate().FirstOrDefault();

            Assert.NotNull(result);
            Assert.IsInstanceOf<Guid>(result.Id);
            Assert.AreEqual(result.Type, AutoPayType.DraftOnDueDate);
            Assert.AreEqual(result.Ok, true);
        }

        [Test]
        public void ProcessDraftOnDueDateShouldFailButSortaGood()
        {
            var processor = new AutoPayProcessorThingy(new[]
            {
                new AutoPay(AutoPayType.DraftOnDay, true, 1)
            });

            var result = processor.ProcessDraftOnDueDate().FirstOrDefault();

            Assert.IsNotNull(result, "result was null");
            Assert.IsInstanceOf<Guid>(result.Id, "Id wasn't a guid!");
            Assert.AreEqual(result.Type, AutoPayType.DraftOnDueDate, "Type is not DraftOnDueDate");
            Assert.AreEqual(result.Ok, true, "Ok is not true!");
        }

        [Test]
        public void ProcessDraftOnDueDateShouldMapPropertiesMultiple()
        {
            var autoPay = new AutoPay(AutoPayType.DraftOnDueDate, true, 1);
            var processor = new AutoPayProcessorThingy(new[]
            {
                autoPay
            });

            var result = processor.ProcessDraftOnDueDate().FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(autoPay.Id));
                Assert.That(result.Type == autoPay.Type);
            });
        }
        
        [Test]
        public void ProcessDraftOnDueDateShouldReturnANullResult()
        {
            var processor = new AutoPayProcessorThingy(new[]
            {
                new AutoPay(AutoPayType.DraftOnDay, true, 1)
            });

            var result = processor.ProcessDraftOnDueDate().FirstOrDefault();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ProcessDraftOnDueDateShouldReturnAnEmptyList()
        {
            var autoPay = new AutoPay(AutoPayType.DraftOnDueDate, false, 1);
            var processor = new AutoPayProcessorThingy(new[]
            {
                autoPay
            });

            Assert.That(() => processor.ProcessDraftOnDueDate(), Is.Empty);
        }

        [Test]
        public void ProcessDraftOnDateShouldNotBeNullAndReturnOkay()
        {
            var autoPay = new AutoPay(AutoPayType.DraftOnDueDate, true, 1);
            var processor = new AutoPayProcessorThingy(new[]
            {
                autoPay
            });

            Assert.That(() => processor.ProcessDraftOnDueDate().FirstOrDefault(),
                Is.Not.Null.And.Property(nameof(AutoPayProcessingResult.Ok)).True);
        }
    }
}