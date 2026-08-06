using System.IO;
using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// File-based repository.
    /// </summary>
    public class PersistenceRepository : IRepository
    {
        private readonly string _filePath = "Contacts.csv";

        /// <summary>
        /// SaveContacts
        /// </summary>
        /// <param name="contacts">list of contacts</param>
        public void SaveContacts(List<Contact> contacts)
        {
            List<string> lines = new List<string>();

            foreach (Contact contact in contacts)
            {
                lines.Add(
                    $"{contact.Name}," +
                    $"{contact.PhoneNumber}," +
                    $"{contact.Email}," +
                    $"{contact.Notes}");
            }

            File.WriteAllLines(_filePath, lines);
        }

        /// <summary>
        /// LoadContacts
        /// </summary>
        /// <returns>list of contacts</returns>
        public List<Contact> LoadContacts()
        {
            List<Contact> contacts = new List<Contact>();

            if (!File.Exists(this._filePath))
            {
                return contacts;
            }

            string[] lines = File.ReadAllLines(this._filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if (values.Length >= 4)
                {
                    contacts.Add(new Contact
                    {
                        Name = values[0],
                        PhoneNumber = values[1],
                        Email = values[2],
                        Notes = values[3],
                    });
                }
            }

            return contacts;
        }

        /// <summary>
        /// Adds contacts
        /// </summary>
        /// <param name="contact">contacts</param>
        public void AddContact(Contact contact)
        {
            string line =
                $"{contact.Name}," +
                $"{contact.PhoneNumber}," +
                $"{contact.Email}," +
                $"{contact.Notes}";

            File.AppendAllLines(this._filePath, new[] { line });
        }

        /// <summary>
        /// Deletes contact
        /// </summary>
        /// <param name="contact">contacts</param>
        public void DeleteContact(Contact contact)
        {
            List<Contact> contacts = this.LoadContacts();

            Contact? existingContact = contacts.FirstOrDefault(c =>
                c.Name == contact.Name &&
                c.PhoneNumber == contact.PhoneNumber &&
                c.Email == contact.Email);

            if (existingContact != null)
            {
                contacts.Remove(existingContact);
                this.SaveContacts(contacts);
            }
        }

        /// <summary>
        /// Updates contact.
        /// </summary>
        /// <param name="oldContact">old Contact</param>
        /// <param name="updatedContact">new contact</param>
        public void UpdateContact(Contact oldContact, Contact updatedContact)
        {
            List<Contact> contacts = this.LoadContacts();

            Contact? existingContact = contacts.FirstOrDefault(c =>
                c.Name == oldContact.Name &&
                c.PhoneNumber == oldContact.PhoneNumber &&
                c.Email == oldContact.Email);

            if (existingContact != null)
            {
                existingContact.Name = updatedContact.Name;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
                existingContact.Email = updatedContact.Email;
                existingContact.Notes = updatedContact.Notes;

                this.SaveContacts(contacts);
            }
        }
    }
}