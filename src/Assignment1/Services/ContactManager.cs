using ContactManagerApp.Helpers;
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
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="repository">The contact repository.</param>
        public ContactManager(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Adds contact.
        /// </summary>
        /// <param name="contact">Conatct</param>
        /// <returns>Boolean value</returns>
        public bool AddContact(Contact contact)
        {
            bool isValid = true;
            if (!string.IsNullOrWhiteSpace(contact.Name) &&
                !ValidationHelper.IsValidName(contact.Name))
            {
                System.Console.WriteLine("\n Invalid Name");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(contact.PhoneNumber) &&
                !ValidationHelper.IsValidPhoneNumber(
                    contact.PhoneNumber))
            {
                System.Console.WriteLine(
                    "\n Invalid Phone Number");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(contact.Email) &&
                !ValidationHelper.IsValidEmail(contact.Email))
            {
                System.Console.WriteLine(
                    "\n Invalid Email");
                isValid = false;
            }

            if (isValid == false)
            {
                return isValid;
            }
            else
            {
                this._repository.AddContact(contact);
            }

            return isValid;
        }

        /// <summary>
        /// Gets the contact
        /// </summary>
        /// <returns>contacts</returns>
        public List<Contact> GetAllContacts()
        {
            return this._repository.LoadContacts();
        }

        /// <summary>
        /// Searches contacts
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Contact</returns>
        public string? SearchContact(string name)
        {
            List<Contact> contacts =
                this._repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (string.Equals(contacts[i].Name, name, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(contacts[i].PhoneNumber, name, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(contacts[i].Email, name, StringComparison.OrdinalIgnoreCase))
                {
                    return contacts[i].ToString();
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
                this._repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == name)
                {
                    this._repository.DeleteContact(
                        contacts[i]);

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
        public bool EditContact(
            string oldName,
            Contact updatedContact)
        {
            List<Contact> contacts =
                this._repository.LoadContacts();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == oldName)
                {
                    this._repository.UpdateContact(
                        contacts[i],
                        updatedContact);

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
                this._repository.LoadContacts();

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

            this._repository.SaveContacts(
                contacts);
        }
    }
}