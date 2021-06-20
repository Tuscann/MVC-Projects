using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BorrowInAndOut.Models__DomainClasses_
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Borrower { get; set; }
        public string Lender { get; set; }

        [DisplayName("item name")]
        public string ItemName { get; set; }
    }
}