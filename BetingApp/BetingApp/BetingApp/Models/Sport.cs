using System.Collections.Generic;
using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Sport
    {
        [XmlAttribute(AttributeName = "ID")]
        public long Id;
        [XmlAttribute]
        public string Name;

        [XmlElement(ElementName = "Event")]
        public List<Event> Events { get; set; }
    }
}
