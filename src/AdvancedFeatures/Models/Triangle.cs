namespace AdvancedFeatures.Models
{
    /// <summary>
    /// Triangle
    /// </summary>
    internal class Triangle : Shape
    {
        /// <summary>
        /// Gets or sets base
        /// </summary>
        /// <value>
        /// Base
        /// </value>
        public double Base { get; set; }

        /// <summary>
        /// Gets or sets height
        /// </summary>
        /// <value>
        /// Height
        /// </value>
        public double Height { get; set; }

        /// <summary>
        /// Calculates area
        /// </summary>
        /// <returns>double</returns>
        public double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
}
