using ContactManagerApp.Helpers;
using ContactManagerApp.Models;
using ContactManagerApp.Repository;
using ContactManagerApp.Services;

string filePath = @"Data\contacts.txt";

ContactRepository repository =
    new ContactRepository(filePath);

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
                Console.ReadLine();

            Console.Write("Phone Number: ");
            contact.PhoneNumber =
                Console.ReadLine();

            Console.Write("Email: ");
            contact.Email =
                Console.ReadLine();

            Console.Write("Notes: ");
            contact.Notes =
                Console.ReadLine();

            if (!ValidationHelper
                .IsValidName(contact.Name))
            {
                Console.WriteLine("Invalid Name");
                break;
            }

            if (!ValidationHelper
                .IsValidPhoneNumber(
                contact.PhoneNumber))
            {
                Console.WriteLine(
                    "Invalid Phone Number");
                break;
            }

            if (!ValidationHelper
                .IsValidEmail(
                contact.Email))
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

            string oldName =
                Console.ReadLine();

            Contact updatedContact =
                new Contact();

            Console.Write("New Name : ");
            updatedContact.Name =
                Console.ReadLine();

            Console.Write("New Phone : ");
            updatedContact.PhoneNumber =
                Console.ReadLine();

            Console.Write("New Email : ");
            updatedContact.Email =
                Console.ReadLine();

            Console.Write("New Notes : ");
            updatedContact.Notes =
                Console.ReadLine();

            if (manager.EditContact(
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

            string deleteName =
                Console.ReadLine();

            if (manager
                .DeleteContact(deleteName))
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

            string searchName =
                Console.ReadLine();

            Contact result =
                manager.SearchContact(
                searchName);

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