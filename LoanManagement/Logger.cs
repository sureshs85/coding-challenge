using log4net;
using System;
using System.Reflection;

namespace LoanManagement
{
    public class Logger
    {
        private static Logger instance;
        protected readonly ILog LOG = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void Log(string msg)
        {
            LOG.Error(msg);
        }
        public void Log(string msg, Exception ex)
        {
            LOG.Error(msg, ex);
        }
        public void Log(Exception ex)
        {
            LOG.Error(ex);
        }
    }
}