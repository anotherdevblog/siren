using Siren.Data.Models;
using System;
using System.Net;
using System.Net.Http;

namespace Siren.GeneralMonitorConfigurations
{
    public class SirenHttpPollingMonitorConfiguration : SirenDataMonitorConfiguration
    {
        private static readonly string CONFIGURATION_NAME = "HTTP Polling";
        private static readonly string CONFIGURATION_CODE = "HTTP_POLLING";

        public override string ConfigurationName => CONFIGURATION_NAME;
        public override string ConfigurationCode => CONFIGURATION_CODE;

        public string URL { get; set; }
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
        public string RequestBodyContains { get; set; }
        public HttpStatusCode StatusCodeIs { get; set; } = HttpStatusCode.OK;
        public TimeSpan PollEvery { get; set; } = TimeSpan.FromMinutes(15);
    }
}
