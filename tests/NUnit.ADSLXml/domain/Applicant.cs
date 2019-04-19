using ADSL.Attributes.Property;
using ADSL.Xml.Attributes.Type;
using ADSL.Xml.Enums;

namespace NUnit.ADSLXml.domain
{
    [XmlMapper(ParentNodeName = "Applicant", MappingOperation = XmlMappingOperation.NODE)]
    public class Applicant
    {
        [Name("name")]
        public string FirstName;

        [Name("surname")]
        public string LastName;
    }
}
