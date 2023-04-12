using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExceptions
{
    public class Actions
    {
        public Result MethodInfo()
        {
            string message = "Start method: MethodInfo()";
            Logger.Instance.Log(new LogRecord { Type = LogType.Info, Message = message });

            return new Result
            {
                Status = true,
                Message = message
            };
        }

        public void MethodWarning()
        {
            string message = "Skipped logic in method: MethodWarning()";

            try
            {
                throw new BusinessException(message);
            }
            catch
            {
                Logger.Instance.Log(new LogRecord { Type = LogType.Warning, Message = "Action got this custom Exception :" + message });
            }
        }

        public void MethodError()
        {
            try
            {
                throw new Exception("I broke a logic.");
            }
            catch (Exception ex)
            {
                string message = "Action failed by a reason: Exception occurred in MethodError(): " + ex.Message;
                Logger.Instance.Log(new LogRecord { Type = LogType.Error, Message = message });
            }
        }
    }
}
