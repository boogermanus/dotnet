using System;
using System.Collections.Generic;

namespace AssertYourself
{
    public class AutoPayProcessorThingy
    {
        private IEnumerable<AutoPay> _autoPays;

        public AutoPayProcessorThingy(IEnumerable<AutoPay> autoPays)
        {
            _autoPays = autoPays;
        }

        public IEnumerable<AutoPayProcessingResult> ProcessDraftOnDueDate()
        {
            var list = new List<AutoPayProcessingResult>();
            foreach (var autoPay in _autoPays)
            {
                if (autoPay.ShouldProcess)
                {
                    if (autoPay.Type == AutoPayType.DraftOnDueDate)
                    {
                        autoPay.DoSomeAutoPayStuff();
                        list.Add(new AutoPayProcessingResult(true, string.Empty)
                        {
                            Id = autoPay.Id,
                            Type = autoPay.Type
                        });
                    }
                }
            }
            
            return list;
        }

        public IEnumerable<AutoPayProcessingResult> ProcessDraftOnDueDateBadIdea()
        {
            return new[]
            {
                new AutoPayProcessingResult(false, string.Empty)
                {
                    Id = Guid.Empty
                }
            };
        }

        public IEnumerable<AutoPayProcessingResult> ProcessDraftOnDueDateThrowsSomething()
        {
            foreach (var autoPay in _autoPays)
            {
                autoPay.DoSomeAutoPayStuffThatThrows();
            }

            return new List<AutoPayProcessingResult>();
        }
        
        public IEnumerable<AutoPayProcessingResult> ProcessDraftOnDueDateThrowsSomethingWithBurn()
        {
            foreach (var autoPay in _autoPays)
            {
                autoPay.DoSomeAutoPayStuffThatThrowsWithMessage();
            }

            return new List<AutoPayProcessingResult>();
        }
    }
}