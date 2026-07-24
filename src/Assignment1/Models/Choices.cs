namespace ContactManagerApp.Models
{
    /// <summary>
    /// Menu choices for Contact Manager.
    /// </summary>
    public enum Choices
    {
        /// <summary>
        /// Adds contact.
        /// </summary>
        AddContact = 1,

        /// <summary>
        /// Views contacts.
        /// </summary>
        ViewContact,

        /// <summary>
        /// Edits contact.
        /// </summary>
        EditContact,

        /// <summary>
        /// Deletes contact.
        /// </summary>
        DeleteContact,

        /// <summary>
        /// Searches contact.
        /// </summary>
        SearchContact,

        /// <summary>
        /// Sorts contacts.
        /// </summary>
        SortContact,

        /// <summary>
        /// Exits application.
        /// </summary>
        Exit,
    }
}