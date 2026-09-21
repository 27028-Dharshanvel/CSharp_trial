using System.Text;

namespace GenericsAndCollections
{
    /// <summary>
    /// Demonstrates collections and generics.
    /// </summary>
    internal class GenericsAndCollection
    {
        /// <summary>
        /// Demonstrates List collection.
        /// </summary>
        public void DemonstrateList()
        {
            List<string> books = new List<string>();

            // Add five books
            books.Add("Gilli");
            books.Add("Mankatha");
            books.Add("Anjaan");
            books.Add("Endhiran");
            books.Add("Vikram");

            // Remove a book
            books.Remove("Endhiran");

            // Check whether a book exists
            if (books.Contains("Gilli"))
            {
                Console.WriteLine("Gilli is found in the list.");
            }

            // Display all books
            Console.WriteLine("\nList of Books:");

            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }

        /// <summary>
        /// Demonstrates Stack collection by reversing a string.
        /// </summary>
        /// <param name="sampleString">String to reverse.</param>
        public void DemonstrateStack(string sampleString)
        {
            Stack<char> stack = new Stack<char>();

            StringBuilder reversedString = new StringBuilder();

            // Push each character into the stack
            for (int i = 0; i < sampleString.Length; i++)
            {
                stack.Push(sampleString[i]);
            }

            // Pop each character from the stack
            for (int i = 0; i < sampleString.Length; i++)
            {
                reversedString.Append(stack.Pop());
            }

            Console.WriteLine(
                $"\nOriginal string : {sampleString}");

            Console.WriteLine(
                $"Reversed string : {reversedString}");
        }

        /// <summary>
        /// Demonstrates Queue collection.
        /// </summary>
        public void DemonstrateQueue()
        {
            Queue<string> persons = new Queue<string>();

            // Add five people
            persons.Enqueue("Veera Ragavan");
            persons.Enqueue("Rayappan");
            persons.Enqueue("Leo Das");
            persons.Enqueue("Jhon Durairaj");
            persons.Enqueue("Vetri Maran");

            // Remove the first person
            string removedPerson = persons.Dequeue();

            Console.WriteLine(
                $"\nRemoved person : {removedPerson}");

            // Display remaining people
            Console.WriteLine("\nPeople remaining in queue:");

            foreach (string person in persons)
            {
                Console.WriteLine(person);
            }
        }

        /// <summary>
        /// Demonstrates Dictionary collection.
        /// </summary>
        public void DemonstrateDictionary()
        {
            Dictionary<string, int> students =
                new Dictionary<string, int>();

            // Add five students and their grades
            students.Add("Dharshan", 90);
            students.Add("Arun", 85);
            students.Add("Karthik", 78);
            students.Add("Rahul", 92);
            students.Add("Vijay", 88);

            // Remove a student
            students.Remove("Rahul");

            // Display students and grades
            Console.WriteLine("\nStudents and Grades:");

            foreach (KeyValuePair<string, int> student in students)
            {
                Console.WriteLine(
                    $"{student.Key} : {student.Value}");
            }
        }

        /// <summary>
        /// Calculates the sum of elements.
        /// </summary>
        /// <param name="elements">Collection of integers.</param>
        /// <returns>Sum of all elements.</returns>
        public int SumOfElements(IEnumerable<int> elements)
        {
            int sum = 0;

            foreach (int element in elements)
            {
                sum += element;
            }

            return sum;
        }

        /// <summary>
        /// Demonstrates IEnumerable with different collection types.
        /// </summary>
        public void DemonstrateIEnumerable()
        {
            List<int> list = new List<int>
            {
                1,
                2,
                3,
                4,
                5,
            };

            int[] array =
            {
                10,
                20,
                30,
                40,
                50,
            };

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);

            Console.WriteLine("\nSum of List:");
            Console.WriteLine(SumOfElements(list));

            Console.WriteLine("\nSum of Array:");
            Console.WriteLine(SumOfElements(array));

            Console.WriteLine("\nSum of Queue:");
            Console.WriteLine(SumOfElements(queue));
        }

        /// <summary>
        /// Creates and returns a read-only dictionary.
        /// </summary>
        /// <returns>Read-only dictionary.</returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> dictionary =
                new Dictionary<string, int>();

            dictionary.Add("Apple", 100);
            dictionary.Add("Banana", 200);
            dictionary.Add("Orange", 300);

            return dictionary;
        }

        /// <summary>
        /// Prints a read-only dictionary.
        /// </summary>
        /// <param name="dictionary">Read-only dictionary.</param>
        public void PrintDictionary(
            IReadOnlyDictionary<string, int> dictionary)
        {
            Console.WriteLine("\nRead-Only Dictionary:");

            foreach (KeyValuePair<string, int> item in dictionary)
            {
                Console.WriteLine(
                    $"{item.Key} : {item.Value}");
            }
        }

        /// <summary>
        /// Demonstrates that the dictionary cannot be modified
        /// through IReadOnlyDictionary.
        /// </summary>
        public void DemonstrateReadOnlyDictionary()
        {
            IReadOnlyDictionary<string, int> dictionary =
                GenerateDictionary();

            PrintDictionary(dictionary);

            Console.WriteLine(
                @"The dictionary cannot be modified through
IReadOnlyDictionary.");
        }
    }
}