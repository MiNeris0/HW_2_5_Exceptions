using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExceptions
{
    public class Starter
    {
        public static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Result result = null;
                Actions actions = new Actions();

                int indexMethod = new Random().Next(1, 4);
                switch (indexMethod)
                {
                    case 1:
                        result = actions.MethodInfo();
                        break;
                    case 2:
                        result = actions.MethodWarning();
                        break;
                    case 3:
                        result = actions.MethodError();
                        break;
                }

                if (result != null && !result.Status)
                {
                    Logger.Instance.Log(new LogRecord { Type = LogType.Error, Message = "Action failed by a reason: " + result.Message });
                }

                File.WriteAllText("log.txt", Logger.Instance.GetText());
            }
        }
    }
}
