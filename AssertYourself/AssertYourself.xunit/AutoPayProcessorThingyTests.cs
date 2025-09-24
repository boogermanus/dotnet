namespace AssertYourself.xunit;

public class AutoPayProcessorThingyTests
{
    [Fact]
    public void ProcessDraftOnDueDateShouldProcessCorrectly()
    {
        var autoPay = new AutoPay(AutoPayType.DraftOnDueDate, true, 1);
        var processor = new AutoPayProcessorThingy([
            autoPay
        ]);

        var result = processor.ProcessDraftOnDueDate().FirstOrDefault();

        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.IsType<Guid>(result.Id);
            Assert.Equal(autoPay.Type, result.Type);
        });
    }

    [Fact]
    public void ProcessDraftOnDueDateThrowsSomething()
    {
        var autoPay = new AutoPay(AutoPayType.DraftOnDay, false, 0);
        var processor = new AutoPayProcessorThingy([
            autoPay
        ]);

        Assert.ThrowsAny<Exception>(() => processor.ProcessDraftOnDueDateThrowsSomething());
    }

    [Fact]
    public void ProcessDraftOnDueDateThrowsSomethingWithMessage()
    {
        var autoPay = new AutoPay(AutoPayType.DraftOnDay, false, 0);
        var processor = new AutoPayProcessorThingy([
            autoPay
        ]);

        var ex = Record.Exception(() => processor.ProcessDraftOnDueDateThrowsSomethingWithBurn());
        
        Assert.Contains("burn",  ex?.Message);
    }
}