using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
    public class EventHandlerPool
    {
        /// <summary>
        /// 用于通知资源池有资源
        /// </summary>
        public ManualResetEvent ManualreseteventHaveResourcesInPool { get; set; }
        /// <summary>
        /// 用于通知打印队列有资源
        /// </summary>
        public ManualResetEvent ManualreseteventHaveResourcesInQueue { get; set; }
        public EventHandlerPool() {
            ManualreseteventHaveResourcesInPool = new ManualResetEvent(false);
            ManualreseteventHaveResourcesInQueue = new ManualResetEvent(false);
        }
    }
}
