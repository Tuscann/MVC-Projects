using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Odd
    {
        [XmlAttribute(AttributeName = "ID")]
        public long Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlAttribute]
        public decimal Value { get; set; }

        public long BetId { get; set; }
        public Bet Bet { get; set; }
    }
}
