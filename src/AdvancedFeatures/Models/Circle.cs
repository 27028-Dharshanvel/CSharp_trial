namespace AdvancedFeatures.Models
{
    /// <summary>
    /// Circle
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Gets or sets radius
        /// </summary>
        /// <value>
        /// radius
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates area of the circle
        /// </summary>
        /// <returns>double</returns>
        public double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
