using ContactManagerApp.Models;

namespace ContactManagerApp.Repository
{
    /// <summary>
    /// ContactRepository
    /// </summary>
    public class ContactRepository
    {
        private List<Contact> _contacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// ContactRepository
        /// </summary>
        public ContactRepository()
        {
            this._contacts = new List<Contact>();
        }

        /// <summary>
        /// saves contact
        /// </summary>
        /// <param name="contacts">contact</param>
        public void SaveContacts(List<Contact> contacts)
        {
            this._contacts = contacts;
        }

        /// <summary>
        /// Loads contacts
        /// </summary>
        /// <returns>contacts</returns>
        public List<Contact> LoadContacts()
        {
            return this._contacts;
        }

        /// <summary>
        /// Adds contact
        /// </summary>
        /// <param name="contact">Contact</param>
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Deletes contact
        /// </summary>
        /// <param name="contact">Contact</param>
        public void DeleteContact(Contact contact)
        {
            this._contacts.Remove(contact);
        }

        /// <summary>
        /// Updates contact
        /// </summary>
        /// <param name="oldContact">Old Contact</param>
        /// <param name="updatedContact">Updated Contact</param>
        public void UpdateContact(Contact oldContact, Contact updatedContact)
        {
            oldContact.Name = updatedContact.Name;
            oldContact.PhoneNumber = updatedContact.PhoneNumber;
            oldContact.Email = updatedContact.Email;
            oldContact.Notes = updatedContact.Notes;
        }
    }
}