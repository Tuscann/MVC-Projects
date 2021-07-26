using System;

namespace DotNet6_webApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string NickName { get; set; }
        public string Place { get; set; }
        public DateTime DataCreated { get; set; } = DateTime.Now;
        public bool isDeleted { get; set; }
    }
}
