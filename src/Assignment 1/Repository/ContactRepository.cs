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
            _contacts = new List<Contact>();
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
            return _contacts;
        }
    }
}