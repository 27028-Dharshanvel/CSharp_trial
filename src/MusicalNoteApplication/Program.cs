using MusicalNoteApplication;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            MusicalPlayer player = new MusicalPlayer();

            Console.WriteLine(@"Musical Scale Player
Available notes: C C# D D# E F F# G G# A A# B
Sample note : C A D D#...");

            Console.Write("Enter notes: ");
            string input = Console.ReadLine() ?? "";

            Console.Write("Enter duration ");
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine("Enter valid integer . Application exiting");
            }

            int duration = 150;
            List<MusicalNote> sequence = player.CreateSequence(input, duration);

            Console.WriteLine("\nPlaying sequence...");
            player.Play(sequence);

            Console.WriteLine("\nFinished.");
        }
    }
}