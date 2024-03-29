﻿using System.Reflection;
using ADSL.Cache.Context;
using ADSL.Xml.Attributes.Property;
using ADSL.Interfaces;

namespace ADSL.Xml.Context
{
    class XmlPropertyAttributeContext : AbstractAttributeContext
    {
        public XmlPropertyAttributeContext(IFieldPropertyInfo property) : base(property)
        {
            XmlListAttribute = GetAttribute<XmlListAttribute>();
            XmlPropertyConverterAttribute = GetAttribute<XmlPropertyConverterAttribute>();
            XmlFlattenHierarchyAttribute = GetAttribute<XmlFlattenHierarchyAttribute>();
            XmlDictionaryAttribute = GetAttribute<XmlDictionaryAttribute>();

            HasXmlListAttribute = XmlListAttribute != null;
            HasXmlPropertyConverterAttribute = XmlPropertyConverterAttribute != null;
            HasXmlFlattenHierarchyAttribute = XmlFlattenHierarchyAttribute != null;
            HasXmlDictionaryAttribute = XmlDictionaryAttribute != null;
        }

        public XmlListAttribute XmlListAttribute { get; private set; }
        public XmlPropertyConverterAttribute XmlPropertyConverterAttribute { get; private set; }
        public XmlFlattenHierarchyAttribute XmlFlattenHierarchyAttribute { get; private set; }
        public XmlDictionaryAttribute XmlDictionaryAttribute { get; private set; }

        public bool HasXmlListAttribute { get; private set; }  
        public bool HasXmlPropertyConverterAttribute { get; private set; }
        public bool HasXmlFlattenHierarchyAttribute { get; private set; }
        public bool HasXmlDictionaryAttribute { get; private set; }
    }
}
