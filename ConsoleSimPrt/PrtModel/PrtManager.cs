using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
     /// <summary>
     /// 打印调度
     /// </summary>
    public class PrtManager
    {
        ResourcePool _resPool;
        Queue<Resource> _resQueue;
        PrtMachine _prtMachine=new PrtMachine();
 
        EventHandlerPool _eventhandlerpool;
        public PrtManager(ResourcePool resPool, EventHandlerPool eventhandlerpool)
        {
            _resPool = resPool;
            _resQueue = new Queue<Resource>();
            _eventhandlerpool = eventhandlerpool;
        }
        /// <summary>
        /// 扫描资源池
        /// </summary>
        public void Scan()
        {
            while (true)
            {
                if (_resPool.ResPool.Count <= 0)
                {
                    Console.WriteLine("暂时没有资源...");
                   
                }
                _eventhandlerpool.ManualreseteventHaveResourcesInPool.WaitOne();
                foreach (var item in _resPool.ResPool)
                {

                    if (!item.IsLocked)
                    {
                        lock (item)
                        {
                            Console.WriteLine(item.Name + "等待打印...");
                            _resQueue.Enqueue(item);
                            _eventhandlerpool.ManualreseteventHaveResourcesInQueue.Set();
                            item.IsLocked = true;
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// 处理打印队列
        /// </summary>
        public void Handle()
        {
            while (true)
            {
                if (_resQueue.Count <= 0)
                {
                    Console.WriteLine("暂时不需要打印...");
                   
                }
                _eventhandlerpool.ManualreseteventHaveResourcesInQueue.WaitOne();
               
                Resource res = _resQueue.Dequeue();
                
                if (res != null)
                {
                    if (_prtMachine.Print(res))
                    {
                        _resPool.RemoveByName(res.Name);
                        Console.WriteLine(res.Name + "打印完毕");
                        Console.WriteLine(_resPool);
                    }
                }
                if (_resQueue.Count <= 0) {
                    _eventhandlerpool.ManualreseteventHaveResourcesInQueue.Reset();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
