using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSL.Cache
{
    public class MetaDataEntry
    {
        public Type Interface { get; set; }
        public Type Type { get; set; }
        public Type Validator { get; set; }
    }
}
