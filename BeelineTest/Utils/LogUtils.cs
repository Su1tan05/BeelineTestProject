using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeelineTest.Utils
{
    public static class LogUtils
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(LogUtils));

        public static void Info(String message)
        {
            log.Info(message);
        }

        public static void error(String message)
        {
            log.Error(message);
        }
    }
}
