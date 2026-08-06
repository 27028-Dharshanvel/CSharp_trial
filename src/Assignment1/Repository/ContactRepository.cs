using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// In-memory contact repository.
    /// </summary>
    public class ContactRepository : IRepository
    {
        private List<Contact> _contacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// Initializes ContactRepository.
        /// </summary>
        public ContactRepository()
        {
            this._contacts = new List<Contact>();
        }

        /// <summary>
        /// Savecontacts
        /// </summary>
        /// <param name="contacts">contacts</param>
        public void SaveContacts(List<Contact> contacts)
        {
            this._contacts = contacts;
        }

        /// <summary>
        /// Loads Contacts.
        /// </summary>
        /// <returns>list of contacts.</returns>
        public List<Contact> LoadContacts()
        {
            return this._contacts;
        }

        /// <summary>
        /// Adds Contacts.
        /// </summary>
        /// <param name="contact">contact</param>
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Deletes Contacts.
        /// </summary>
        /// <param name="contact">contact</param>
        public void DeleteContact(Contact contact)
        {
            this._contacts.Remove(contact);
        }

        /// <summary>
        /// Update Contacts.
        /// </summary>
        /// <param name="oldContact">oldcontact</param>
        /// <param name="updatedContact">updatedContact</param>
        public void UpdateContact(Contact oldContact, Contact updatedContact)
        {
            oldContact.Name = updatedContact.Name;
            oldContact.PhoneNumber = updatedContact.PhoneNumber;
            oldContact.Email = updatedContact.Email;
            oldContact.Notes = updatedContact.Notes;
        }
    }
}