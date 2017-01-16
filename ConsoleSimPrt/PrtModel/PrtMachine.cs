using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
    /// <summary>
    /// 打印机
    /// </summary>
    public class PrtMachine
    {
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool Print(Resource res)
        {
            try
            {
                Console.WriteLine("打印:" + res.Name + "开始...");
                Thread.Sleep(5000);
                Console.WriteLine("打印:" + res.Name + "结束...");
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
