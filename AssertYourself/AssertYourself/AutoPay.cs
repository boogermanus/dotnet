using System;

namespace AssertYourself
{
    public class AutoPay
    {
        public AutoPay(AutoPayType type, bool shouldProcess, int day)
        {
            Id = Guid.NewGuid();
            Type = type;
            ShouldProcess = shouldProcess;
            Day = day;
        }
        
        public Guid Id { get; set; }
        public AutoPayType Type { get; set; }
        public int Day { get; set; }
        public bool ShouldProcess { get; set; }
        public bool WasProcessed { get; set; }
        public void DoSomeAutoPayStuffThatThrows() => throw new NotImplementedException();
        public bool IsDay(int day) => day == Day;

        public void SetTheDraftDayIfZero(int day)
        {
            if (day == 0)
            {
                Day = 0;
                Type = AutoPayType.DraftOnDueDate;
            }
        }

        public void DoSomeAutoPayStuff()
        {
            WasProcessed = true;
        }
    }
}