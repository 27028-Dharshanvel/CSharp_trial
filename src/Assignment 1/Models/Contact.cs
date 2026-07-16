namespace ContactManagerApp.Models
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact
    {
        public Guid ContactId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public Contact()
        {
            ContactId = Guid.NewGuid();
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Notes = string.Empty;
        }
    }
}