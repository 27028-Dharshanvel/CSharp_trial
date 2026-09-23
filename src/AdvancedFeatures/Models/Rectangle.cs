namespace AdvancedFeatures.Models
{
    /// <summary>
    /// Rectangle
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets length
        /// </summary>
        /// <value>
        /// Length
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets width
        /// </summary>
        /// <value>
        /// Width
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Calculates Area
        /// </summary>
        /// <returns>double</returns>
        public double CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
}
