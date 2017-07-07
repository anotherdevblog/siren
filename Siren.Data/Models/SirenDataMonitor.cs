using System;
using System.Collections.Generic;
using System.Text;
using Siren.Common;
using Newtonsoft.Json;

namespace Siren.Data.Models
{
    public abstract class SirenDataMonitor : SirenDataModel
    {
        internal object ConfigurationObject { get; set; }
    }

    public class SirenDataMonitor<T> : SirenDataMonitor where T : SirenDataMonitorConfiguration
    {
        [JsonIgnore]
        public T Configuration
        {
            get
            {
                return ConfigurationObject as T;
            }
            set
            {
                ConfigurationObject = value;
            }
        }
    }
}
