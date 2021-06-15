using System.Collections.Generic;
using System.Xml.Serialization;

namespace BettingApp.Models
{
    [XmlRoot()]
    public class XmlSports
    {
        [XmlElement(ElementName = "Sport")]
        public List<Sport> Sports { get; set; }
    }
}
