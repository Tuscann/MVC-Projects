using System.Collections.Generic;
using System.Xml.Serialization;

namespace BettingApp.Models
{
    public class Event
    {
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute(AttributeName ="ID")]        
        public long Id { get; set; }
        [XmlAttribute()]
        public bool IsLive { get; set; }
        [XmlAttribute(AttributeName = "CategoryID")]
        public long CategoryId { get; set; }

        //[XmlElement(ElementName = "Match")]
        //public List<Match> Matches { get; set; }
        public long SportId { get; set; }
        public Sport Sport { get; set; }

    }
}
