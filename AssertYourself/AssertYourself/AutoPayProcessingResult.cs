using System;

namespace AssertYourself
{
    public class AutoPayProcessingResult
    {
        public AutoPayProcessingResult(bool ok, string message)
        {
            Ok = ok;
            Message = message;
        }
        public bool Ok { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
        public AutoPayType Type { get; set; }
    }
}