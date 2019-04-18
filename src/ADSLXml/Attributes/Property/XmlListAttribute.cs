using ADSL.Xml.Interfaces;
using System;
using System.Collections;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace ADSL.Xml.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class XmlListAttribute : Attribute, IXmlAttributeMarker
    {
        public string NodeName { get; set; }

        public XmlListAttribute()
        {
            NodeName = "List";
        }
    }
}
