using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Odd
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public long Id { get; set; }
        [XmlAttribute()]
        public decimal Value { get; set; }       
    }
}
