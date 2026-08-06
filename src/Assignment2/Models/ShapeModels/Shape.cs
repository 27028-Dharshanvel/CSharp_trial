namespace Assignment2.ShapeModels
{
    /// <summary>
    /// Shape
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets colour.
        /// </summary>
        /// <value>
        /// Colour as a string.
        /// </value>
        public string Colour { get; set; } = string.Empty;

        /// <summary>
        /// Gets shapeType.
        /// </summary>
        /// <value>
        /// Shapes type as string.
        /// </value>
        public abstract string ShapeType { get; }

        /// <summary>
        /// Calculates area of the shape.
        /// </summary>
        /// <returns>Area in double </returns>
        public abstract double CalculateArea();
    }
}
