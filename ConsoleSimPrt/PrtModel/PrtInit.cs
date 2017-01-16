using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
    /// <summary>
    /// 程序模拟初始化
    /// </summary>
    public class PrtInit
    {
        public static EventHandlerPool eventhandlerpool = new EventHandlerPool();
        public static ResourcePool PrtResourcePool = new ResourcePool(eventhandlerpool);
        public static Client client = new Client(PrtResourcePool);
        public static PrtManager prtManager = new PrtManager(PrtResourcePool, eventhandlerpool);
        public static void Init()
        {
            StringBuilder strbDexc = new StringBuilder();
            strbDexc.AppendLine("打印机模拟程序-by JinLiwei 2016-12-31");
            strbDexc.AppendLine("O------0   0------0   0--------0   0------0");
            strbDexc.AppendLine("|客户端|-》|资源池|-》|打印队列|-》|打印机|");
            strbDexc.AppendLine("0------0   0------0   0--------0   0------0");

            Console.WriteLine(strbDexc.ToString());

            Action actSacn = new Action(prtManager.Scan);
            Task.Run(actSacn);

            Action actHandle = new Action(prtManager.Handle);
            Task.Run(actHandle);

            while (true)
            {
                string str =Console.ReadLine();
                Resource res = new Resource { Name = str };
                client.Push(res);
                Console.WriteLine(PrtResourcePool);
                Thread.Sleep(10);

            }
        }

    }
}
