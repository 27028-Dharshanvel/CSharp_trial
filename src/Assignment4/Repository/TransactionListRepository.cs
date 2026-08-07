using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Transaction List Repository.
    /// </summary>
    internal class TransactionListRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionListRepository"/> class.
        /// Initializes ContactRepository.
        /// </summary>
        public TransactionListRepository()
        {
            this._transactions = new List<Transaction>();
        }

        /// <summary>
        /// Savecontacts
        /// </summary>
        /// <param name="contacts">contacts</param>
        public void SaveContacts(List<Transaction> contacts)
        {
            this._transactions = contacts;
        }

        /// <summary>
        /// Loads Contacts.
        /// </summary>
        /// <returns>list of contacts.</returns>
        public List<Transaction> LoadContacts()
        {
            return this._transactions;
        }

        /// <summary>
        /// Adds Contacts.
        /// </summary>
        /// <param name="contact">contact</param>
        public void AddContact(Transaction contact)
        {
            this._transactions.Add(contact);
        }

        /// <summary>
        /// Deletes Contacts.
        /// </summary>
        /// <param name="contact">contact</param>
        public void DeleteContact(Transaction contact)
        {
            this._transactions.Remove(contact);
        }

        /// <summary>
        /// Update Contacts.
        /// </summary>
        /// <param name="oldTransaction">oldcontact</param>
        /// <param name="updatedTransaction">updatedContact</param>
        public void UpdateContact(Transaction oldTransaction, Transaction updatedTransaction)
        {
            oldTransaction.Amount = updatedTransaction.Amount;
            oldTransaction.Date = updatedTransaction.Date;
            oldTransaction.Category = updatedTransaction.Category;
        }
    }
}
