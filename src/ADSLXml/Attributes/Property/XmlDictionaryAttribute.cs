using ADSL.Xml.Enums;
using ADSL.Xml.Interfaces;
using System;

namespace ADSL.Xml.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class XmlDictionaryAttribute : Attribute, IXmlAttributeMarker
    {
        public XmlMappingOperation MappingOperation { get; set; }

        public XmlDictionaryAttribute()
        {
            MappingOperation = XmlMappingOperation.ATTRIBUTE;
        }
    }
}
