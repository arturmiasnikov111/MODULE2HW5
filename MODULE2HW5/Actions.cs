using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using MODULE2HW5.Helpers;

namespace MODULE2HW5
{
    public class Actions
    {
        public bool StartMethod()
        {
            var logger = Logger.Instance;
            logger.Info($"{nameof(StartMethod)}");
            return true;
        }

        public void SkippedLogic()
        {
            throw new SkippedLogicException("Action got failed by a reason: ");
        }

        public void BrokeLogic()
        {
            throw new Exception("Some Needed Exception");
        }
    }
}