using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siren.Data.Models
{
    public abstract class SirenDataMonitorConfiguration
    {
        [JsonIgnore]
        public abstract string ConfigurationName { get; }

        [JsonIgnore]
        public abstract string ConfigurationCode { get; }
    }
}
