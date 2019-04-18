using ADSL.Interfaces;
using System;

namespace ADSL.Attributes.Type
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class IncludeInScanAttribute : Attribute, IAttributeMarker
    {
    }
}
