using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// Repository contract for contact operations.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Save Contacts.
        /// </summary>
        /// <param name="contacts">contacts</param>
        void SaveContacts(List<Contact> contacts);

        /// <summary>
        /// Loads Contact.
        /// </summary>
        /// <returns>List</returns>
        List<Contact> LoadContacts();

        /// <summary>
        /// Adds Contact.
        /// </summary>
        /// <param name="contact">contact</param>
        void AddContact(Contact contact);

        /// <summary>
        /// Deletes Contacts.
        /// </summary>
        /// <param name="contact">contacts</param>
        void DeleteContact(Contact contact);

        /// <summary>
        /// Save Contacts.
        /// </summary>
        /// <param name="oldContact">old contact</param>
        /// <param name="updatedContact">updated contact</param>
        void UpdateContact(Contact oldContact, Contact updatedContact);
    }
}