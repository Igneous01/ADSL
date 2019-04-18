using ADSL.Xml.Interfaces;
using System;
using System.Xml.Linq;

namespace ADSL.Xml.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class XmlFlattenHierarchyAttribute : Attribute, IXmlAttributeMarker
    {
    }
}
