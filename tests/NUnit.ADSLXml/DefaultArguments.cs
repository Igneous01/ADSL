// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using ADSL.Xml.Attributes.Type;
using ADSL.Xml.Enums;
using ADSL.Attributes.Property;
using ADSL.Xml.Mapper;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Reflection;
using NUnit.ADSLXml.utils;

namespace NUnit.ADSLXml
{
    [XmlMapper()]
    sealed class SampleClass
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public double Money;
        public List<string> References;
    }

    [TestFixture]
    public class DefaultArguments
    {
        public static object[] SampleClassProperties = typeof(SampleClass).GetProperties();

        private SampleClass Instance;
        private XmlMapper<SampleClass> Mapper;
        private string ExpectedXml = @"
<Xml>
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <Age>30</Age>
    <Money>87000.413</Money>
    <References>
        <String>Jane Doe</String>
        <String>Edward Smith</String>
        <String>Will Smith</String>
    </References>
</Xml>";
        

        [SetUp]
        public void SetupBeforeEachTest()
        {
            this.Instance = new SampleClass()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Money = 87000.413,
                References = new List<string>() { "Jane Doe", "Edward Smith", "Will Smith" }
            };

            this.Mapper = new XmlMapper<SampleClass>();
        }

        [Test]
        public void XmlMatches()
        {
            XmlDocument value = Mapper.MapToXmlDocument(Instance);
            XmlDocument originalXml = new XmlDocument();
            originalXml.LoadXml(ExpectedXml);
            Assert.IsTrue(XmlSoftEqualityComparer.Equals(value, originalXml), "Generated Xml string does not match");
        }

        [Test]
        public void XmlStringValid()
        {
            string value = Mapper.MapToXmlString(Instance);
            Assert.DoesNotThrow(() =>
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(value);
            }, "Generated Xml string is invalid", null);
        }

        [TestCaseSource(nameof(SampleClassProperties))]
        public void XmlPropertyExists(object property)
        {
            XmlDocument xmlDocument = Mapper.MapToXmlDocument(Instance);
            Assert.That(xmlDocument.SelectSingleNode($"//{property}"), Is.Not.Null, $"{property} does not exist in xml");
        }

        [TestCase("FirstName", "John")]
        [TestCase("LastName", "Doe")]
        [TestCase("Age", "30")]
        [TestCase("Money", "87000.413")]
        public void XmlPropertyValueEquals(string property, object value)
        {
            XmlDocument xmlDocument = Mapper.MapToXmlDocument(Instance);
            XmlNode node = xmlDocument.SelectSingleNode($"//{property}");
            Assert.That(node.InnerText, Is.EqualTo(value), $"{property} node value does not match");
        }

        [TestCase("References/String", new string[] { "Jane Doe", "Edward Smith", "Will Smith" })]
        public void SerializedEnumerableNodeCountMatchesExpected(string property, string[] value)
        {
            int valueCount = value.Length;
            XmlDocument xmlDocument = Mapper.MapToXmlDocument(Instance);
            XmlNodeList nodes = xmlDocument.SelectNodes($"//{property}");
            Assert.That(nodes.Count, Is.EqualTo(valueCount));        
        }

        [TestCase("References/String", "Jane Doe")]
        [TestCase("References/String", "Edward Smith")]
        [TestCase("References/String", "Will Smith")]
        public void SerializedEnumerableValueMatchesExpected(string property, string value)
        {
            XmlDocument xmlDocument = Mapper.MapToXmlDocument(Instance);
            XmlNodeList nodes = xmlDocument.SelectNodes($"//{property}");
            IEnumerable<XmlNode> results = nodes.Cast<XmlNode>()
                                                .Where((XmlNode node) => node.InnerText.Equals(value))
                                                .Select((XmlNode node) => node);
            Assert.That(results.Count, Is.EqualTo(1), $"Could not find any nodes of {property} with the value {value}");
        }
    }
}
