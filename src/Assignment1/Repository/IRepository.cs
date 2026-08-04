using System.Collections.Generic;
using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// Represents the repository interface for managing contacts.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves contacts.
        /// </summary>
        /// <param name="contacts">contacts</param>
        void SaveContacts(List<Contact> contacts);

        /// <summary>
        /// Loads contacts.
        /// </summary>
        /// <returns>contacts</returns>
        List<Contact> LoadContacts();

        /// <summary>
        /// Adds contact.
        /// </summary>
        /// <param name="contact">Contact</param>
        void AddContact(Contact contact);

        /// <summary>
        /// Deletes contact.
        /// </summary>
        /// <param name="contact">Contact</param>
        void DeleteContact(Contact contact);

        /// <summary>
        /// Updates contact.
        /// </summary>
        /// <param name="oldContact">Old Contact</param>
        /// <param name="updatedContact">Updated Contact</param>
        void UpdateContact(Contact oldContact, Contact updatedContact);
    }
}
