namespace Assignments
{
    /// <summary>
    /// Entry point class for the application.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> phones = new List<string>();
            List<string> names = new List<string>();
            List<string> emails = new List<string>();
            List<string> notes = new List<string>();
            Console.WriteLine("******* Contact Manager Application ******");
            Console.WriteLine("1.Add contact");
            Console.WriteLine("2.View contact");
            Console.WriteLine("3.Edit contact");
            Console.WriteLine("4.Delete contact");
            Console.WriteLine("5.Search contacts");
            Console.WriteLine("6.Sort contact");

            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Add contact");
                    Console.WriteLine("Enter the name");
                    names.Add(Console.ReadLine());
                    Console.WriteLine("Enter the Phone no.");
                    phones.Add(Console.ReadLine());
                    Console.WriteLine("Enter the Email");
                    emails.Add(Console.ReadLine());
                    Console.WriteLine("Enter Notes");
                    notes.Add(Console.ReadLine());
                    Console.WriteLine("Contact Added Successfully");
                    break;
                case 2:
                    Console.WriteLine("View contact");
                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.Write("Name: " + names[i]);
                        Console.Write("Phone: " + phones[i]);
                        Console.Write("Email: " + emails[i]);
                        Console.Write("Note: " + notes[i]);
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Edit contact");

                    break;
                case 4:
                    Console.WriteLine("Delete contact");
                    break;
                case 5:
                    Console.WriteLine("Enter name to Search");
                    string tempName = Console.ReadLine();
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i] == tempName)
                        {
                            Console.WriteLine("Name: " + names[i]);
                            Console.WriteLine("Phone: " + phones[i]);
                            Console.WriteLine("Email: " + emails[i]);
                            Console.WriteLine("Notes: " + notes[i]);
                            break;
                        }
                    }
                    break;
                case 6:
                    Console.WriteLine("Sort Contacts");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}