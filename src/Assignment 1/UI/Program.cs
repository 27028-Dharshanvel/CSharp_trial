using System;
using System.Collections.Generic;
using ContactManagerApp.Models;
using ContactManagerApp.Repository;
using ContactManagerApp.Services;

string filePath = @"C:\Users\dharshanvel.velumani\Downloads\CSharp_trial\src\Assignment 1\Data\contacts.json";

ContactRepository repository = new ContactRepository(filePath);

ContactManager manager = new ContactManager(repository);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== Contact Manager =====");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View Contacts");
    Console.WriteLine("3. Edit Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("5. Search Contact");
    Console.WriteLine("6. Sort Contacts");
    Console.WriteLine("7. Exit");

    Console.Write("Enter Choice: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid Input");
        continue;
    }

    switch (choice)
    {
        case 1:

            Contact contact = new Contact();

            Console.Write("Name: ");
            contact.Name = Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            contact.Email = Console.ReadLine() ?? "";

            Console.Write("Notes: ");
            contact.Notes = Console.ReadLine() ?? "";

            manager.AddContact(contact);

            Console.WriteLine("Contact Added Successfully");
            break;

        case 2:

            var contacts = manager.GetAllContacts();

            foreach (var item in contacts)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Phone: {item.PhoneNumber}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine($"Notes: {item.Notes}");
            }

            break;

        case 3:

            Console.Write("Enter Contact Name: ");
            string oldName = Console.ReadLine() ?? "";

            Contact updatedContact = new Contact();

            Console.Write("New Name: ");
            updatedContact.Name = Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            updatedContact.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            updatedContact.Email = Console.ReadLine() ?? "";

            Console.Write("Notes: ");
            updatedContact.Notes = Console.ReadLine() ?? "";

            bool updated =
                manager.EditContact(
                    oldName,
                    updatedContact);

            Console.WriteLine(
                updated
                ? "Contact Updated"
                : "Contact Not Found");

            break;

        case 4:

            Console.Write("Enter Name: ");

            string deleteName =
                Console.ReadLine() ?? "";

            bool deleted =
                manager.DeleteContact(deleteName);

            Console.WriteLine(
                deleted
                ? "Contact Deleted"
                : "Contact Not Found");

            break;

        case 5:

            Console.Write("Enter Name: ");

            string searchName =
                Console.ReadLine() ?? "";

            Contact? result =
                manager.SearchContact(searchName);

            if (result == null)
            {
                Console.WriteLine("Contact Not Found");
            }
            else
            {
                Console.WriteLine($"Name : {result.Name}");
                Console.WriteLine($"Phone: {result.PhoneNumber}");
                Console.WriteLine($"Email: {result.Email}");
                Console.WriteLine($"Notes: {result.Notes}");
            }

            break;

        case 6:

            manager.SortContacts();

            Console.WriteLine("Contacts Sorted");
            break;

        case 7:

            return;

        default:

            Console.WriteLine("Invalid Choice");
            break;
    }
}