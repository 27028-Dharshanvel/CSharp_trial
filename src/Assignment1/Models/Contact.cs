namespace ContactManagerApp.Models
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets contactId
        /// </summary>
        /// <value>
        ///  Contact id
        /// </value>
        public Guid ContactId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Phonenumber
        /// </summary>
        /// <value>
        /// Phonenumber
        /// </value>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        /// <value>
        /// Email
        /// </value>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets notes
        /// </summary>
        /// <value>
        /// Notes
        /// </value>
        public string Notes { get; set; } = string.Empty;
    }
}