using System;
using ADSL.Abstracts;
using ADSL.Utils;
using ADSL.Xml.Interfaces;
using ADSL.Exceptions;

namespace ADSL.Xml.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class XmlPropertyConverterAttribute : AbstractPropertyConverterAttribute, IXmlAttributeMarker
    {
        public XmlPropertyConverterAttribute(System.Type converter) : base(converter)
        {
            System.Type IPropertyConverter = typeof(IXmlPropertyConverter<>);
            if (!ReflectionUtils.IsAssignableToGenericType(converter, IPropertyConverter))
                throw new InterfaceNotImplementedException("Type " + converter.AssemblyQualifiedName + " does not implement interface " + IPropertyConverter.AssemblyQualifiedName);
        }
    }
}
