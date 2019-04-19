using ADSL.Xml.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NUnit.ADSLXml.utils
{
    public static class XmlSoftEqualityComparer
    {
        public static bool Equals(XmlDocument left, XmlDocument right)
        {
            return XNode.DeepEquals(left.ToXDocument(), right.ToXDocument());
        }
    }
}
