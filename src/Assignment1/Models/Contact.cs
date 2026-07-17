namespace ContactManagerApp.Models
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// Contact
        /// </summary>
        public Contact()
        {
            this.ContactId = Guid.NewGuid();
            this.Name = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
            this.Notes = string.Empty;
        }

        /// <summary>
        /// Gets or sets contactId
        /// </summary>
        /// <value>
        ///  Contact id
        /// </value>
        public Guid ContactId { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Notes { get; set; }
    }
}