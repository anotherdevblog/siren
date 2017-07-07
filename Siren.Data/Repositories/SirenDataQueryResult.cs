using Siren.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siren.Data.Repositories
{
    public class SirenDataQueryResult
    {
        public Exception Exception { get; set; }
        public bool Succes => Exception != null;
    }

    public class SirenDataQueryResultSingle<T> : SirenDataQueryResult where T : SirenDataModel
    {
        public T Value { get; set; }
        public bool Found => Value != null;
    }

    public class SirenDataQueryResultBatch<T> : SirenDataQueryResult where T : SirenDataModel
    {
        public IList<T> Values { get; set; }
        public bool Any => Values?.Count > 0;
    }
}
