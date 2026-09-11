using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections
{
    /// <summary>
    /// Generics and collections class.
    /// </summary>
    internal class GenericsAndCollection
    {
        /// <summary>
        /// Demonstration of list.
        /// </summary>
        public void DemonstrateList()
        {
            List<string> books = new List<string>();
            books.Add("Gilli");
            books.Add("Mankatha");
            books.Add("Anjaan");
            books.Add("Endhiran");
            books.Add("Vikram");

            books.Remove("Endhran");

            if (books.Contains("Gilli"))
            {
                Console.WriteLine("BookFound");
            }
            Console.WriteLine("List of Books : ");
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }

        /// <summary>
        /// Demonstrate stack.
        /// </summary>
        /// <param name="sampleString">string</param>
        public void DemonstrateStack(string sampleString)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder reversedString = null;
            for (int i = 0; i < sampleString.Length; i++)
            {
                stack.Push(sampleString[i]);
            }

            for (int i = 0; i < sampleString.Length; i++)
            {
                reversedString.Append(stack.Pop());
            }

            Console.WriteLine($"Reversed string : {reversedString} ");
        }

        /// <summary>
        /// Demonstration of Queue
        /// </summary>
        public void DemonstrateQueue()
        {
            Queue<string> persons = new Queue<string>();
            persons.Enqueue("Veera Ragavan");
            persons.Enqueue("Rayappan");
            persons.Enqueue("Leo Das");
            persons.Enqueue("Jhon Durairaj");
            persons.Enqueue("Vetri maran");

            persons.Dequeue();
        }
    }
}
