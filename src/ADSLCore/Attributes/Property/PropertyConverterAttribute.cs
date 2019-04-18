using ADSL.Abstracts;
using ADSL.Interfaces;
using System;

namespace ADSL.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PropertyConverterAttribute : AbstractPropertyConverterAttribute, ICommonAttributeMarker
    {
        public PropertyConverterAttribute(System.Type converter) : base(converter)
        {
        }
    }
}
