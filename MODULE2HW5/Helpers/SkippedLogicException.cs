using System;

namespace MODULE2HW5.Helpers
{
    public class SkippedLogicException : Exception
    {
        public SkippedLogicException(string reason) : base(reason)
        {
        }
    }
}