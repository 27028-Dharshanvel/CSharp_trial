using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Interface for Transaction Repository.
    /// </summary>
    internal interface ITransactionRepository
    {
        /// <summary>
        /// Save Contacts.
        /// </summary>
        /// <param name="transactions">contacts</param>
        void SaveContacts(List<Transaction> transactions);

        /// <summary>
        /// Loads Contact.
        /// </summary>
        /// <returns>List</returns>
        List<Transaction> LoadContacts();

        /// <summary>
        /// Adds Contact.
        /// </summary>
        /// <param name="transaction">contact</param>
        void AddContact(Transaction transaction);

        /// <summary>
        /// Deletes Contacts.
        /// </summary>
        /// <param name="transaction">contacts</param>
        void DeleteContact(Transaction transaction);

        /// <summary>
        /// Save Contacts.
        /// </summary>
        /// <param name="oldTransaction">old contact</param>
        /// <param name="updatedTransaction">updated contact</param>
        void UpdateContact(Transaction oldTransaction, Transaction updatedTransaction);
    }
}
