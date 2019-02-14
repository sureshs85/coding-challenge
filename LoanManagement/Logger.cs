namespace LoanManagement
{
    using log4net;
    using System;
    using System.Reflection;

    public class Logger
    {
        private static Logger instance;
        protected readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            _log.Error(msg);
        }
        public void Log(string msg, Exception ex)
        {
            _log.Error(msg, ex);
        }
        public void Log(Exception ex)
        {
            _log.Error(ex);
        }
    }
}