using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    [XmlRoot("person")]
    public class PersonWithAttributes
    {
        [XmlElement("name")]
        public string FirstName { get; set; }
        [XmlIgnore]
        public string LastName { get; set; }
        [XmlAttribute("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }

}
