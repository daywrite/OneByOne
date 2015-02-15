using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBone.Core.Data.Entity.Monitors
{
    public class RedisCacheMonitor : IEquatable<RedisCacheMonitor>
    {
        public string Key { get { return MonitorConstant.REDIS_KEY; } }

        public string TableName { get; set; }

        public string[] Fields { get; set; }

        #region IEquatable<RedisCacheMonitor> 成员

        public bool Equals(RedisCacheMonitor other)
        {
            if (other == null)
            {
                return false;
            }

            return this.TableName == other.TableName;
        }

        #endregion
    }
}
