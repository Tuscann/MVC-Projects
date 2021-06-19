using System;
using System.Collections.Generic;

namespace LibraryData.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public double Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
