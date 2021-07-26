using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OutletsAndContacts
{
    class Program
    {
        public static List<Outlet> LoadOutletsFromJson(List<Contact> contacts, string newPath)
        {
            using (StreamReader reader = new StreamReader(newPath + "Outlets.json"))
            {
                string json = reader.ReadToEnd();

                List<Outlet> readOutLets = JsonConvert.DeserializeObject<List<Outlet>>(json);

                for (int y = 0; y < contacts.Count; y++)
                {
                    for (int i = 0; i < readOutLets.Count; i++)
                    {
                        if (readOutLets[i].Id == contacts[y].OutletId)
                        {
                            int index = readOutLets.IndexOf(readOutLets.Where(p => p.Id == readOutLets[i].Id).FirstOrDefault());                        

                            readOutLets[index].Contacts.Add(contacts[y]);
                        }
                    }

                }
                return readOutLets;
            }
        }

        public static List<Contact> LoadContactsFromJson(string newPath)
        {
            using (StreamReader reader = new StreamReader(newPath + "Contacts.json"))
            {
                string json = reader.ReadToEnd();
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);

                return contacts;
            }
        }

        static void Main()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));

            List<Contact> inputContacts = LoadContactsFromJson(newPath);
            List<Outlet> outlets = LoadOutletsFromJson(inputContacts, newPath);

            Console.WriteLine("Write search term ");

            string searchItem = Console.ReadLine();

            List<Contact> matchingContacts = inputContacts
                .Where(contact =>
                   contact.LastName == searchItem
                || contact.Title == searchItem
                || contact.Profile.Contains(searchItem)
                )
                .ToList();

            List<Outlet> resultOutlets = outlets.Where(x => x.Name.Contains(searchItem)).ToList();
            List<Contact> printedContacts = new List<Contact>();

            for (int i = 0; i < resultOutlets.Count; i++)
            {
                for (int y = 0; y < resultOutlets[i].Contacts.Count; y++)
                {
                    printedContacts.Add(resultOutlets[i].Contacts[y]);
                }
            }

            for (int i = 0; i < matchingContacts.Count; i++)
            {
                if (!printedContacts.Contains(matchingContacts[i]))
                {
                    printedContacts.Add(matchingContacts[i]);
                }
            }

            PrintOnConsole(outlets, printedContacts);
        }

        private static void PrintOnConsole(List<Outlet> outlets, List<Contact> printedContacts)
        {
            for (int i = 0; i < printedContacts.Count; i++)
            {
                Console.WriteLine("Contact Name : " + printedContacts[i].FirstName + " " + printedContacts[i].LastName);
                Console.WriteLine("Contact Title : " + printedContacts[i].Title);

                Outlet outlet = outlets.Where(x => x.Id == printedContacts[i].OutletId).First();

                Console.WriteLine("Outlet Name : " + outlet.Name);
                Console.WriteLine("Contact Profile : " + printedContacts[i].Profile);
                Console.WriteLine();
            }
        }
    }
}

