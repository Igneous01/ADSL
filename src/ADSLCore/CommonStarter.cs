using ADSL.Cache;
using ADSL.Cache.Context;
using ADSL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSL
{
    class CommonStarter : IStarter
    {
        public void Start()
        {
            MetaDataRegistry.Register<ICommonAttributeMarker, PropertyAttributeContext>();
        }
    }
}
