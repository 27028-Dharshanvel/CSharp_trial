namespace MusicalNoteApplication
{
    /// <summary>
    /// MusicalNote
    /// </summary>
    internal class MusicalNote
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicalNote"/> class.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="frequency">Frequency</param>
        /// <param name="duration">Duration</param>
        public MusicalNote(string name, double frequency, int duration)
        {
            this.Name = name;
            this.Frequency = frequency;
            this.Duration = duration;
        }

        /// <summary>
        /// Gets or sets name of the music note
        /// </summary>
        /// <value>
        /// Name of the music
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets frequency
        /// </summary>
        /// <value>
        /// Frequency of the music
        /// </value>
        public double Frequency { get; set; }

        /// <summary>
        /// Gets or sets duration
        /// </summary>
        /// <value>
        /// Duration of the music
        /// </value>
        public int Duration { get; set; }
    }
}
