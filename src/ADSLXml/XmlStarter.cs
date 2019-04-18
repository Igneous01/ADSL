using ADSL.Cache;
using ADSL.Interfaces;
using ADSL.Xml.Context;
using ADSL.Xml.Interfaces;
using ADSLXml.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSLXml
{
    class XmlStarter : IStarter
    {
        public void Start()
        {
            MetaDataRegistry.Register<IXmlAttributeMarker, XmlPropertyAttributeContext, XmlPropertyAttributeValidator>();
        }
    }
}
