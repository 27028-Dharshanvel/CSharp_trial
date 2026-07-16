using System;
using System.Collections.Generic;
using ContactManagerApp.Helpers;
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

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search Contact");
                Console.WriteLine("6. Sort Contacts");
                Console.WriteLine("7. Exit");

                Console.Write("Enter Choice: ");

                int choice =
                    Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

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

                        if (!string.IsNullOrWhiteSpace(contact.Name) && !ValidationHelper.IsValidName(contact.Name))
                        {
                            Console.WriteLine("Invalid Name");
                            break;
                        }

                        if (!string.IsNullOrWhiteSpace(contact.PhoneNumber) && !ValidationHelper
                            .IsValidPhoneNumber(
                            contact.PhoneNumber))
                        {
                            Console.WriteLine(
                                "Invalid Phone Number");
                            break;
                        }

                        if (!string.IsNullOrWhiteSpace(contact.Email) && !ValidationHelper.IsValidEmail(contact.Email))
                        {
                            Console.WriteLine(
                                "Invalid Email");
                            break;
                        }

                        manager.AddContact(contact);

                        Console.WriteLine(
                            "Contact Added");

                        break;

                    case 2:

                        List<Contact> contacts =
                            manager.GetAllContacts();

                        for (int i = 0;
                             i < contacts.Count;
                             i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine(
                                "ID : " +
                                contacts[i].ContactId);

                            Console.WriteLine(
                                "Name : " +
                                contacts[i].Name);

                            Console.WriteLine(
                                "Phone : " +
                                contacts[i].PhoneNumber);

                            Console.WriteLine(
                                "Email : " +
                                contacts[i].Email);

                            Console.WriteLine(
                                "Notes : " +
                                contacts[i].Notes);
                        }

                        break;

                    case 3:

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

                        if (!string.IsNullOrWhiteSpace(oldName) && manager.EditContact(
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

                    case 4:

                        Console.Write(
                            "Enter Name To Delete : ");

                        string? deleteName =
                            Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(deleteName) && manager.DeleteContact(deleteName))
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

                    case 5:

                        Console.Write(
                            "Enter Name To Search : ");

                        string? searchName =
                            Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(searchName))
                            {
                            break;
                            }

                        Contact? result = manager.SearchContact(searchName);

                        if (result != null)
                        {
                            Console.WriteLine(result.Name);
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
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

                    case 6:

                        manager.SortContacts();

                        Console.WriteLine(
                            "Contacts Sorted");

                        break;

                    case 7:

                        return;

                    default:

                        Console.WriteLine(
                            "Invalid Choice");

                        break;
                }
            }
        }
    }
}