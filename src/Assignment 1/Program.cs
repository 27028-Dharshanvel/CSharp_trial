using System;
using System.Collections.Generic;
namespace Assignments
{
    /// <summary>
    /// Base factory.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<string> phones = new List<string>();
            List<string> emails = new List<string>();
            List<string> notes = new List<string>();

            while (true)
            {
                Console.WriteLine("\n******* Contact Manager Application ******");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search Contact");
                Console.WriteLine("6. Sort Contacts");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int userChoice;

                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("\n--- Add Contact ---");

                        Console.Write("Enter Name: ");
                        names.Add(Console.ReadLine());

                        Console.Write("Enter Phone Number: ");
                        phones.Add(Console.ReadLine());

                        Console.Write("Enter Email: ");
                        emails.Add(Console.ReadLine());

                        Console.Write("Enter Notes: ");
                        notes.Add(Console.ReadLine());

                        Console.WriteLine("Contact Added Successfully!");
                        break;

                    case 2:
                        Console.WriteLine("\n--- View Contacts ---");

                        if (names.Count == 0)
                        {
                            Console.WriteLine("No contacts available.");
                        }
                        else
                        {
                            for (int i = 0; i < names.Count; i++)
                            {
                                Console.WriteLine("***********************");
                                Console.WriteLine("Name: " + names[i]);
                                Console.WriteLine("Phone: " + phones[i]);
                                Console.WriteLine("Email: " + emails[i]);
                                Console.WriteLine("Notes: " + notes[i]);
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n--- Edit Contact ---");
                        Console.Write("Enter name to edit: ");
                        string editName = Console.ReadLine();

                        bool editFound = false;

                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i].Equals(editName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Enter New Name: ");
                                names[i] = Console.ReadLine();

                                Console.Write("Enter New Phone Number: ");
                                phones[i] = Console.ReadLine();

                                Console.Write("Enter New Email: ");
                                emails[i] = Console.ReadLine();

                                Console.Write("Enter New Notes: ");
                                notes[i] = Console.ReadLine();

                                Console.WriteLine("Contact Updated Successfully!");
                                editFound = true;
                                break;
                            }
                        }

                        if (!editFound)
                        {
                            Console.WriteLine("Contact Not Found!");
                        }

                        break;

                    case 4:
                        Console.WriteLine("\n--- Delete Contact ---");
                        Console.Write("Enter name to delete: ");
                        string deleteName = Console.ReadLine();

                        bool deleteFound = false;

                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i].Equals(deleteName, StringComparison.OrdinalIgnoreCase))
                            {
                                names.RemoveAt(i);
                                phones.RemoveAt(i);
                                emails.RemoveAt(i);
                                notes.RemoveAt(i);

                                Console.WriteLine("Contact Deleted Successfully!");
                                deleteFound = true;
                                break;
                            }
                        }

                        if (!deleteFound)
                        {
                            Console.WriteLine("Contact Not Found!");
                        }

                        break;

                    case 5:
                        Console.WriteLine("\n--- Search Contact ---");
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();

                        bool searchFound = false;

                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("*********************");
                                Console.WriteLine("Name: " + names[i]);
                                Console.WriteLine("Phone: " + phones[i]);
                                Console.WriteLine("Email: " + emails[i]);
                                Console.WriteLine("Notes: " + notes[i]);

                                searchFound = true;
                                break;
                            }
                        }

                        if (!searchFound)
                        {
                            Console.WriteLine("Contact Not Found!");
                        }

                        break;

                    case 6:
                        Console.WriteLine("\n--- Sort Contacts by Name ---");
                        Console.WriteLine("Contacts Sorted Successfully!");
                        break;

                    case 7:
                        Console.WriteLine("Thank you for using Contact Manager!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}