using System.Collections.Generic;

namespace OutletsAndContacts
{
    public class Outlet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
