using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingApp.Models
{
    public class Match
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public string MatchType { get; set; }
    }
}
