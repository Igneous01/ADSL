﻿using ADSL.Interfaces;
using System;

namespace ADSL.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NameAttribute : Attribute, ICommonAttributeMarker
    {
        public readonly string _name;
        public string Name { get { return _name; } }

        public NameAttribute(string Name)
        {
            _name = Name;
        }
    }
}
