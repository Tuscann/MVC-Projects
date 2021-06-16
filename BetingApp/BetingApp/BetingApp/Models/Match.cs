using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Match
    {
        [XmlAttribute(AttributeName = "ID")]
        public long Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public DateTime StartDate { get; set; }

        [XmlAttribute]
        public string MatchType { get; set; }

        [XmlElement(ElementName = "Bet")]
        public List<Bet> Bets { get; set; }

        public long EventId { get; set; }
        public Event Event { get; set; }
    }
}
