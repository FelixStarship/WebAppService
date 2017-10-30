
using NLog;

namespace RedisConsoleApp.Nlog
{
  public  class NLogHelper
    {
        public readonly static Logger Instance = LogManager.GetCurrentClassLogger();
    }
}
