using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Siren.Data.Models;
using System.Linq;

namespace Siren.Data.Repositories
{
    public class MockSirenDataRepository : ISirenDataRepository
    {
        private object _highestIDsLock = new object();
        private Dictionary<Type, long> _highestIDs = new Dictionary<Type, long>();
        private ConcurrentDictionary<Type, ConcurrentDictionary<long, SirenDataModel>> _data = new ConcurrentDictionary<Type, ConcurrentDictionary<long, SirenDataModel>>();

        #region Dashboards

        public SirenDataQueryResultSingle<SirenDataDashboard> GetDashboard(long dashboardID)
        {
            return GetSingle<SirenDataDashboard>(dashboardID);
        }

        public SirenDataQueryResultBatch<SirenDataDashboard> GetAllDashboards()
        {
            return GetAll<SirenDataDashboard>();
        }

        public SirenDataQueryResultSingle<SirenDataDashboard> AddDashboard(SirenDataDashboard dashboard)
        {
            return Add(dashboard);
        }

        public SirenDataQueryResultSingle<SirenDataDashboard> UpdateDashboard(SirenDataDashboard dashboard)
        {
            return Update(dashboard);
        }

        public SirenDataQueryResult DeleteDashboard(long dashboardID)
        {
            return Delete<SirenDataDashboard>(dashboardID);
        }

        #endregion

        #region Monitors

        public SirenDataQueryResultSingle<SirenDataMonitor> GetMonitor(long monitorID)
        {
            return GetSingle<SirenDataMonitor>(monitorID);
        }

        public SirenDataQueryResultBatch<SirenDataMonitor> GetAllMonitors()
        {
            return GetAll<SirenDataMonitor>();
        }

        public SirenDataQueryResultSingle<SirenDataMonitor> AddMonitor(SirenDataMonitor monitor)
        {
            return Add(monitor);
        }

        public SirenDataQueryResultSingle<SirenDataMonitor> UpdateMonitor(SirenDataMonitor monitor)
        {
            return Update(monitor);
        }

        public SirenDataQueryResult DeleteMonitor(long monitorID)
        {
            return Delete<SirenDataMonitor>(monitorID);
        }

        #endregion

        #region General

        private SirenDataQueryResultSingle<T> GetSingle<T>(long id) where T : SirenDataModel
        {
            var thisType = typeof(T);
            var result = new SirenDataQueryResultSingle<T>();
            if (_data.TryGetValue(thisType, out var dict))
            {
                dict.TryGetValue(id, out var val);
                result.Value = val as T;
            }
            return result;
        }

        private SirenDataQueryResultBatch<T> GetAll<T>() where T : SirenDataModel
        {
            var thisType = typeof(T);
            var result = new SirenDataQueryResultBatch<T>();
            if (_data.TryGetValue(thisType, out var dict))
            {
                result.Values = dict.Values.Select(v => v as T).ToArray();
            }
            return result;
        }

        private SirenDataQueryResultSingle<T> Add<T>(T val) where T : SirenDataModel
        {
            var thisType = typeof(T);
            val.ID = GetNextID(thisType);
            return Update(val);
        }

        private SirenDataQueryResultSingle<T> Update<T>(T val) where T : SirenDataModel
        {
            var thisType = typeof(T);
            var dict = _data.GetOrAdd(thisType, new ConcurrentDictionary<long, SirenDataModel>());
            return new SirenDataQueryResultSingle<T>
            {
                Value = (dict[val.ID] = val) as T
            };
        }

        private long GetNextID(Type thisType)
        {
            long nextID;
            lock (_highestIDsLock)
            {
                if (!_highestIDs.ContainsKey(thisType))
                {
                    _highestIDs[thisType] = 1;
                }
                nextID = _highestIDs[thisType]++;
            }
            return nextID;
        }

        private SirenDataQueryResult Delete<T>(long id) where T : SirenDataModel
        {
            var thisType = typeof(T);
            if (_data.TryGetValue(thisType, out var dict))
            {
                dict.TryRemove(id, out _);
            }

            return new SirenDataQueryResult();
        }

        #endregion
    }
}
