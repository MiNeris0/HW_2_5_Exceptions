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
            FileService.Run();
            for (int i = 0; i < 100; i++)
            {
                Actions actions = new Actions();

                int indexMethod = new Random().Next(1, 4);
                switch (indexMethod)
                {
                    case 1:
                        actions.MethodInfo();
                        break;
                    case 2:
                        actions.MethodWarning();
                        break;
                    case 3:
                        actions.MethodError();
                        break;
                }
            }

            Logger.Instance.WriteLogs();
        }
    }
}
