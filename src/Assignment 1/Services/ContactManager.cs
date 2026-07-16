using ContactManagerApp.Models;
using ContactManagerApp.Repository;

namespace ContactManagerApp.Services
{
    /// <summary>
    /// Class ContactManager
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        /// Class ContactManager
        /// </summary>
        private readonly ContactRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="repository">The contact repository.</param>
        public ContactManager(ContactRepository repository)
        {
            this._repository = repository;
        }
        /// <summary>
        /// Adds contact.
        /// </summary>
        /// <param name="contact">Conatct</param>
        public void AddContact(Contact contact)
        {
            List<Contact> contacts =
                _repository.LoadContacts();

            contacts.Add(contact);

            _repository.SaveContacts(contacts);
        }
        /// <summary>
        /// Gets the contact
        /// </summary>
        /// <returns>contacts</returns>
        public List<Contact> GetAllContacts()
        {
            return _repository.LoadContacts();
        }
        /// <summary>
        /// Searches contacts 
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Contact</returns>
        public Contact SearchContact(string name)
        {
            List<Contact> contacts =
                _repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == name)
                {
                    return contacts[i];
                }
            }

            return null;
        }
        /// <summary>
        /// Deletes contact
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>contact</returns>
        public bool DeleteContact(string name)
        {
            List<Contact> contacts =
                _repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == name)
                {
                    contacts.RemoveAt(i);

                    _repository.SaveContacts(contacts);

                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Deletes contact
        /// </summary>
        /// <param name="oldName">Name</param>
        /// <param name="updatedContact">UpdatedContact</param>
        /// <returns>contact</returns>
        public bool EditContact(string oldName, Contact updatedContact)
        {
            List<Contact> contacts =
                _repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == oldName)
                {
                    contacts[i].Name =
                        updatedContact.Name;

                    contacts[i].PhoneNumber =
                        updatedContact.PhoneNumber;

                    contacts[i].Email =
                        updatedContact.Email;

                    contacts[i].Notes =
                        updatedContact.Notes;

                    _repository.SaveContacts(contacts);

                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Sorts contact
        /// </summary>
        /// <param name="name">Name</param>
        public void SortContacts()
        {
            List<Contact> contacts =
                _repository.LoadContacts();

            for (int i = 0;
                 i < contacts.Count - 1;
                 i++)
            {
                for (int j = i + 1;
                     j < contacts.Count;
                     j++)
                {
                    if (string.Compare(
                        contacts[i].Name,
                        contacts[j].Name) > 0)
                    {
                        Contact temp =
                            contacts[i];

                        contacts[i] =
                            contacts[j];

                        contacts[j] =
                            temp;
                    }
                }
            }

            _repository.SaveContacts(contacts);
        }
    }
}