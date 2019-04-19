using ADSL.Attributes.Property;
using ADSL.Xml.Attributes.Type;
using ADSL.Xml.Enums;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.ADSLXml
{
    [TestFixture]
    public class TestClass2
    {
        //[Test]
        //public void TestMethod()
        //{
        //    // TODO: Add your test code here
        //    var answer = 42;
        //    Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        //}

        [XmlMapper(ParentNodeName = "Sample", MappingOperation = XmlMappingOperation.NODE)]
        private class SampleClass
        {
            [Name("name")]
            public string FirstName;

            [Name("surname")]
            public string LastName;
        }
    }
}
