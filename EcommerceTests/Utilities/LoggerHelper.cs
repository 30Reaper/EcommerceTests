using NLog;

namespace EcommerceTests.Utilities
{
    public static class LoggerHelper
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }
    }
}