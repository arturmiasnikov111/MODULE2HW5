using System;
using MODULE2HW5.Services;

namespace MODULE2HW5
{
    public class Starter
    {
        public void Run()
        {
            var fileService = new FileService();
            var action = new Actions();
            var random = new Random();
            var logger = Logger.Instance;
            for (int i = 0; i < 100; i++)
            {
                int temp = random.Next(1, 4);
                switch (temp)
                {
                    case 1:
                        action.StartMethod();
                        break;
                    case 2:
                        try
                        {
                            action.BrokeLogic();
                        }
                        catch (Exception e)
                        {
                            logger.Error($"{e.Message} {e.StackTrace}");
                        }

                        break;
                    case 3:
                        try
                        {
                            action.SkippedLogic();
                        }
                        catch (Exception e)
                        {
                            logger.Warning($"{e.Message} {e.StackTrace}");
                        }

                        break;
                }
            }

            fileService.SaveToFile();
        }
    }
}