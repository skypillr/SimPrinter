using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSimPrt.PrtModel
{
    /// <summary>
    /// 资源池
    /// </summary>
    public class ResourcePool
    {
        public List<Resource> ResPool { get; set; }
        EventHandlerPool _eventhandlerpool;
        public ResourcePool(EventHandlerPool eventhandlerpool) {
            ResPool = new List<Resource>();
            _eventhandlerpool = eventhandlerpool;
        }

        /// <summary>
        /// 资源池增加资源
        /// </summary>
        /// <param name="res"></param>
        public void Add(Resource res) {
            ResPool.Add(res);
            _eventhandlerpool.ManualreseteventHaveResourcesInPool.Set();
        }

        /// <summary>
        /// 资源池移除资源
        /// </summary>
        /// <param name="name"></param>
        public void RemoveByName(string name)
        {
            for(int i=0;i< ResPool.Count;i++)
            {
                if (ResPool[i].Name == name)
                {
                    ResPool.RemoveAt(i);
                    i--;
                }
            }
            if (ResPool.Count <= 0) {
                _eventhandlerpool.ManualreseteventHaveResourcesInPool.Reset();
            }
        }
        public override string ToString()
        {

            StringBuilder strb = new StringBuilder();
            strb.AppendLine();
            strb.AppendLine("资源池最新状态:");
            strb.AppendLine("Existing Resources in ResourcePool...");
            foreach (var item in ResPool)
            {
                strb.Append(item.Name);
                strb.Append(" "+(item.IsLocked?"锁住":"未锁住"));
                strb.Append(Environment.NewLine);
            
            }
            strb.AppendLine("End...");
            return strb.ToString();
        }
    }
}
