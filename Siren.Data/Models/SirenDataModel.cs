using System;
using System.Collections.Generic;
using System.Text;

namespace Siren.Data.Models
{
    public abstract class SirenDataModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
