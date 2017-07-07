using Siren.Data.Models;
using System;

namespace Siren.GeneralMonitorConfigurations
{
    public class SirenHttpPollingMonitorConfiguration : SirenDataMonitorConfiguration
    {
        private static readonly string CONFIGURATION_NAME = "HTTP Polling";
        private static readonly string CONFIGURATION_CODE = "HTTP_POLLING";

        public override string ConfigurationName => CONFIGURATION_NAME;
        public override string ConfigurationCode => CONFIGURATION_CODE;
    }
}
