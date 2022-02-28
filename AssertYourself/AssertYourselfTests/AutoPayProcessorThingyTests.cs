using System;
using System.Linq;
using System.Threading.Tasks;
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

            Assert.IsNotNull(result, "result is null");
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
                Assert.That(result, Is.Not.Null, "result is null");
                Assert.That(result.Id, Is.EqualTo(autoPay.Id),$"{result.Id} is not equal to {autoPay.Id}");
                Assert.That(result.Type == autoPay.Type, "result.Type is not equal to autoPay.Type");
            });
        }
        
        [Test]
        public void ProcessDraftOnDueDateBadIdeaShouldMapPropertiesMultipleCoolMessage()
        {
            var autoPay = new AutoPay(AutoPayType.DraftOnDueDate, true, 1);
            var processor = new AutoPayProcessorThingy(new[]
            {
                autoPay
            });

            var result = processor.ProcessDraftOnDueDateBadIdea().FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null, "result is null");
                Assert.That(result.Id, Is.EqualTo(autoPay.Id),$"{result.Id} is not equal to {autoPay.Id}");
                Assert.That(result.Type == autoPay.Type, "result.Type is not equal to autoPay.Type");
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
        
        // catching exceptions
        [Test]
        public void ProcessDraftOnDueDateThrowsSomethingWillThrow()
        {
            Assert.That(() => new AutoPayProcessorThingy(new[]
            {
                new AutoPay(AutoPayType.DraftOnDay, false, 0)
            }).ProcessDraftOnDueDateThrowsSomething(), Throws.Exception);
        }
        
        [Test]
        public void ProcessDraftOnDueDateThrowsSomethingWillThrowWithBurn()
        {
            Assert.That(() => new AutoPayProcessorThingy(new[]
                {
                    new AutoPay(AutoPayType.DraftOnDay, false, 0)
                }).ProcessDraftOnDueDateThrowsSomethingWithBurn(),
                Throws.InstanceOf<NotSupportedException>().With.Message.Contains("burn"));
        }

        // running async tests
        [Test]
        public async Task ProcessDraftOnDueDateRunsAsync()
        {
            var processor = new AutoPayProcessorThingy(new[]
            {
                new AutoPay(AutoPayType.DraftOnDay, true, 10)
            });

            var result = await processor.ProcessDraftOnDueDateAsync();

            Assert.That(result, Is.Not.Empty.And.All.Not.Null);
        }
    }
}