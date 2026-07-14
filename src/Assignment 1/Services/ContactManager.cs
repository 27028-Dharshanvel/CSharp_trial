using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactManagerApp.Models;
using ContactManagerApp.Repository;
namespace ContactManagerApp.Services
{
    /// <summary>
    /// Base factory.
    /// </summary>
    public class ContactManager
    {
        private readonly ContactRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="repository">
        /// The path to the file used to store contact information.
        /// </param>
        public ContactManager(ContactRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds a contact to the repository.
        /// </summary>
        /// <param name="contact">
        /// The contact to add.
        /// </param>
        public void AddContact(Contact contact)
        {
            List<Contact> contacts = _repository.GetAllContacts();

            contacts.Add(contact);

            _repository.SaveContacts(contacts);
        }
        /// <summary>
        /// Gets all contacts from the repository.
        /// </summary>
        /// <returns>
        /// A list of all contacts.
        /// </returns>
        public List<Contact> GetAllContacts()
        {
            return _repository.GetAllContacts();
        }
        /// <summary>
        /// Searches for a contact by name.
        /// </summary>
        /// <param name="name">
        /// The name of the contact to search for.
        /// </param>
        /// <returns>
        /// The matching contact if found; otherwise, null.
        /// </returns>
        public Contact? SearchContact(string name)
        {
            return _repository
                .GetAllContacts()
                .FirstOrDefault(c =>
                    c.Name.Equals(
                        name,
                        StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// Deletes a contact by name.
        /// </summary>
        /// <param name="name">
        /// The name of the contact to delete.
        /// </param>
        /// <returns>
        /// True if the contact was deleted; otherwise, false.
        /// </returns>
        public bool DeleteContact(string name)
        {
            List<Contact> contacts = _repository.GetAllContacts();

            Contact? contact = contacts
                .FirstOrDefault(c =>
                    c.Name.Equals(
                        name,
                        StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                return false;
            }

            contacts.Remove(contact);

            _repository.SaveContacts(contacts);

            return true;
        }
        /// <summary>
        /// Edits an existing contact.
        /// </summary>
        /// <param name="oldName">The name of the contact to edit.</param>
        /// <param name="updatedContact">The updated contact information.</param>
        /// <returns>
        /// True if the contact was updated successfully; otherwise, false.
        /// </returns>
        public bool EditContact(string oldName, Contact updatedContact)
        {
            List<Contact> contacts = _repository.GetAllContacts();

            Contact? existingContact = contacts
                .FirstOrDefault(c =>
                    c.Name.Equals(
                        oldName,
                        StringComparison.OrdinalIgnoreCase));

            if (existingContact == null)
            {
                return false;
            }

            existingContact.Name = updatedContact.Name;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;
            existingContact.Email = updatedContact.Email;
            existingContact.Notes = updatedContact.Notes;

            _repository.SaveContacts(contacts);

            return true;
        }
        /// <summary>
        /// Sorts the contacts in the repository.
        /// </summary>
        public void SortContacts()
        {
            List<Contact> contacts = _repository.GetAllContacts();

            contacts = contacts
                .OrderBy(c => c.Name)
                .ToList();

            _repository.SaveContacts(contacts);
        }
    }
}