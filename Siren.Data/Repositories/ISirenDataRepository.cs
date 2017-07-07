using Siren.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siren.Data.Repositories
{
    public interface ISirenDataRepository
    {
        // Dashboards
        SirenDataQueryResultSingle<SirenDataDashboard> GetDashboard(long dashboardID);
        SirenDataQueryResultBatch<SirenDataDashboard> GetAllDashboards();
        SirenDataQueryResultSingle<SirenDataDashboard> AddDashboard(SirenDataDashboard dashboard);
        SirenDataQueryResultSingle<SirenDataDashboard> UpdateDashboard(SirenDataDashboard dashboard);
        SirenDataQueryResult DeleteDashboard(long dashboardID);

        // Monitors
        SirenDataQueryResultSingle<SirenDataMonitor> GetMonitor(long monitorID);
        SirenDataQueryResultBatch<SirenDataMonitor> GetAllMonitors();
        SirenDataQueryResultSingle<SirenDataMonitor> AddMonitor(SirenDataMonitor monitor);
        SirenDataQueryResultSingle<SirenDataMonitor> UpdateMonitor(SirenDataMonitor monitor);
        SirenDataQueryResult DeleteMonitor(long monitorID);
    }
}
