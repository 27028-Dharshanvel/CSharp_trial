using System.Collections.Generic;
using System.IO;
using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// PersistenceRepository
    /// </summary>
    public class PersistenceRepository : IRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceRepository"/> class.
        /// PersistenceRepository
        /// </summary>
        public PersistenceRepository()
        {
            this._filePath = "contacts.txt";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceRepository"/> class with custom file path.
        /// </summary>
        /// <param name="filePath">File path</param>
        public PersistenceRepository(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// saves contact
        /// </summary>
        /// <param name="contacts">contact</param>
        public void SaveContacts(List<Contact> contacts)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < contacts.Count; i++)
            {
                Contact c = contacts[i];
                string line = $"{c.ContactId},{c.Name},{c.PhoneNumber},{c.Email},{c.Notes}";
                lines.Add(line);
            }

            File.WriteAllLines(this._filePath, lines);
        }

        /// <summary>
        /// Loads contacts
        /// </summary>
        /// <returns>contacts</returns>
        public List<Contact> LoadContacts()
        {
            List<Contact> contacts = new List<Contact>();

            if (!File.Exists(this._filePath))
            {
                return contacts;
            }

            string[] lines = File.ReadAllLines(this._filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');

                if (parts.Length >= 5)
                {
                    Contact contact = new Contact();

                    if (System.Guid.TryParse(parts[0], out System.Guid id))
                    {
                        contact.ContactId = id;
                    }

                    contact.Name = parts[1];
                    contact.PhoneNumber = parts[2];
                    contact.Email = parts[3];
                    contact.Notes = parts[4];

                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Adds contact
        /// </summary>
        /// <param name="contact">Contact</param>
        public void AddContact(Contact contact)
        {
            List<Contact> contacts = this.LoadContacts();
            contacts.Add(contact);
            this.SaveContacts(contacts);
        }

        /// <summary>
        /// Deletes contact
        /// </summary>
        /// <param name="contact">Contact</param>
        public void DeleteContact(Contact contact)
        {
            List<Contact> contacts = this.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].ContactId == contact.ContactId || contacts[i].Name == contact.Name)
                {
                    contacts.RemoveAt(i);
                    break;
                }
            }

            this.SaveContacts(contacts);
        }

        /// <summary>
        /// Updates contact
        /// </summary>
        /// <param name="oldContact">Old Contact</param>
        /// <param name="updatedContact">Updated Contact</param>
        public void UpdateContact(Contact oldContact, Contact updatedContact)
        {
            List<Contact> contacts = this.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].ContactId == oldContact.ContactId || contacts[i].Name == oldContact.Name)
                {
                    contacts[i].Name = updatedContact.Name;
                    contacts[i].PhoneNumber = updatedContact.PhoneNumber;
                    contacts[i].Email = updatedContact.Email;
                    contacts[i].Notes = updatedContact.Notes;
                    break;
                }
            }

            this.SaveContacts(contacts);
        }
    }
}
