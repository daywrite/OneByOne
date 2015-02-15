using OBone.Caching.Monitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBone.Core.Data.Entity.Monitors
{
    public class MonitorWrapper
    {
        public static void Init(params RedisCacheMonitor[] monitors)
        {
            if (monitors == null)
            {
                return;
            }

            foreach (var monitor in monitors)
            {
                EqualsMonitorManager<string, RedisCacheMonitor>.Add(monitor.Key, monitor);
            }            
        }
    }
}
