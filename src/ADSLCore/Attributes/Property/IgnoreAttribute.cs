using ADSL.Interfaces;
using System;


namespace ADSL.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute, ICommonAttributeMarker
    {
    }
}
