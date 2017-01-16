using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
    public class Client
    {
        ResourcePool _resPool;
 
        public Client(ResourcePool resPool) {
            _resPool = resPool;
            
        }
        /// <summary>
        /// 往资源池送入资源
        /// </summary>
        /// <param name="res"></param>
        public void Push(Resource res) {
            _resPool.Add(res);
            
        }
    }
}
