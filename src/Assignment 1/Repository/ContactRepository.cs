using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ContactManagerApp.Models;
namespace ContactManagerApp.Repository
    {
    /// <summary>
    /// Contact Repository
    /// </summary>
    public class ContactRepository
        {
            private readonly string _filePath;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The path to the file used to store contact information.
        /// </param>
            public ContactRepository(string filePath)
            {
                _filePath = filePath;
             }
        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>
        /// A list containing all contacts.
        /// </returns>
            public List<Contact> GetAllContacts()
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Contact>();
                }

                string json = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Contact>();
                }

                return JsonSerializer.Deserialize<List<Contact>>(json)
                       ?? new List<Contact>();
            }
        /// <summary>
        /// Saves the specified contacts.
        /// </summary>
        /// <param name="contacts">
        /// The list of contacts to save.
        /// </param>
            public void SaveContacts(List<Contact> contacts)
            {
                string json = JsonSerializer.Serialize(
                    contacts,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText(_filePath, json);
            }
        }
    }
