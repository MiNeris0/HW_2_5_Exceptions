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

        public Result MethodWarning()
        {
            string message = "Skipped logic in method: MethodWarning()";
            Logger.Instance.Log(new LogRecord { Type = LogType.Warning, Message = message });

            return new Result
            {
                Status = true,
                Message = message
            };
        }

        public Result MethodError()
        {
            string message = "I broke a logic";
            Logger.Instance.Log(new LogRecord { Type = LogType.Error, Message = message });

            return new Result
            {
                Status = false,
                Message = message
            };
        }
    }
}
