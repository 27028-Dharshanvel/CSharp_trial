using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ContactManagerApp.Models;
using ContactManagerApp.Repository;
using ContactManagerApp.Services;

namespace ContactManagerApp
{
    /// <summary>
    /// Represents Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            ContactRepository repository =
                new ContactRepository();

            ContactManager manager =
                new ContactManager(repository);
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Write("============= ContactManager Console Application =============\n");
                Console.WriteLine(" \n 1. Add Contact \r\n 2. View Contacts \n 3. Edit Contact \n 4. Delete Contact \r\n 5. Search Contact \r\n 6. Sort Contacts  \r\n 7. Exit");
                Console.Write("\nEnter Choice: ");
                string userInput = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(userInput, out int choice) &&
                    Enum.IsDefined(typeof(Choices), choice))
                {
                    Choices userChoice = (Choices)choice;

                    switch (userChoice)
                    {
                        case Choices.AddContact:

                            Contact contact =
                                new Contact();

                            Console.Write("Name: ");
                            contact.Name =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("Phone Number: ");
                            contact.PhoneNumber =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("Email: ");
                            contact.Email =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("Notes: ");
                            contact.Notes =
                                Console.ReadLine() ?? string.Empty;

                            if (manager.AddContact(contact))
                            {
                                Console.WriteLine(
                                    "Contact Added");
                            }

                            break;

                        case Choices.ViewContact:

                            List<Contact> contacts =
                                manager.GetAllContacts();

                            for (int i = 0;
                                 i < contacts.Count;
                                 i++)
                            {
                                Console.WriteLine(contacts[i].ToString());
                            }

                            break;

                        case Choices.EditContact:

                            Console.Write(
                                "Enter Name To Edit : ");

                            string? oldName =
                                Console.ReadLine();

                            Contact updatedContact =
                                new Contact();

                            Console.Write("New Name : ");
                            updatedContact.Name =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("New Phone : ");
                            updatedContact.PhoneNumber =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("New Email : ");
                            updatedContact.Email =
                                Console.ReadLine() ?? string.Empty;

                            Console.Write("New Notes : ");
                            updatedContact.Notes =
                                Console.ReadLine() ?? string.Empty;

                            if (!string.IsNullOrWhiteSpace(oldName) &&
                                manager.EditContact(
                                    oldName,
                                    updatedContact))
                            {
                                Console.WriteLine(
                                    "Contact Updated");
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Contact Not Found");
                            }

                            break;

                        case Choices.DeleteContact:

                            Console.Write(
                                "Enter Name To Delete : ");

                            string? deleteName =
                                Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(deleteName) &&
                                manager.DeleteContact(deleteName))
                            {
                                Console.WriteLine(
                                    "Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Contact Not Found");
                            }

                            break;

                        case Choices.SearchContact:

                            Console.Write(
                                "Enter Name To Search : ");

                            string? searchName =
                                Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(searchName))
                            {
                                break;
                            }

                            Contact? result =
                                manager.SearchContact(searchName);

                            if (result != null)
                            {
                                Console.WriteLine(
                                    result.Name);
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Contact not found.");
                            }

                            if (result != null)
                            {
                                Console.WriteLine(
                                    result.Name);

                                Console.WriteLine(
                                    result.PhoneNumber);

                                Console.WriteLine(
                                    result.Email);

                                Console.WriteLine(
                                    result.Notes);
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Contact Not Found");
                            }

                            break;

                        case Choices.SortContact:

                            manager.SortContacts();

                            Console.WriteLine(
                                "Contacts Sorted");

                            break;

                        case Choices.Exit:

                            Console.WriteLine("\nApplication exited");
                            isAppRunning = false;
                            return;

                        default:

                            Console.WriteLine(
                                "Invalid Choice");

                            break;
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Enter numeric value for choice");
                }
            }
        }
    }
}