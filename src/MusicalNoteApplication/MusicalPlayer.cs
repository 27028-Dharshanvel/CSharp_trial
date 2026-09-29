namespace MusicalNoteApplication
{
    /// <summary>
    /// Musical player
    /// </summary>
    internal class MusicalPlayer
    {
        private readonly Dictionary<string, double> _frequencies = new Dictionary<string, double>()
        {
            { "C", 261.63 },
            { "C#", 277.18 },
            { "D", 293.66 },
            { "D#", 311.13 },
            { "E", 329.63 },
            { "F", 349.23 },
            { "F#", 369.99 },
            { "G", 392.00 },
            { "G#", 415.30 },
            { "A", 440.00 },
            { "A#", 466.16 },
            { "B", 493.88 },
        };

        /// <summary>
        /// Creates the sequence for the music
        /// </summary>
        /// <param name="input">input</param>
        /// <param name="duration">duration of the music</param>
        /// <returns>list of musical note.</returns>
        public List<MusicalNote> CreateSequence(string input, int duration)
        {
            List<MusicalNote> notes = new List<MusicalNote>();

            string[] noteNames = input.Split(' ');

            foreach (string name in noteNames)
            {
                if (this._frequencies.ContainsKey(name))
                {
                    notes.Add(new MusicalNote(name, this._frequencies[name], duration));
                }
                else
                {
                    Console.WriteLine($"Invalid note: {name}");
                }
            }

            return notes;
        }

        /// <summary>
        /// Play the music
        /// </summary>
        /// <param name="notes">notes</param>
        public void Play(List<MusicalNote> notes)
        {
            foreach (MusicalNote note in notes)
            {
                Console.Beep((int)note.Frequency, note.Duration);
            }
        }
    }
}
