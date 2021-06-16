using System.Collections.Generic;
using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Bet
    {
        [XmlAttribute(AttributeName = "ID")]
        public long Id { get; set; }
        
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsLive { get; set; }

        [XmlElement(ElementName = "Odd")]
        public List<Odd> Odds { get; set; }

        public long MatchId { get; set; }
        public Match Match { get; set; }
    }
}
