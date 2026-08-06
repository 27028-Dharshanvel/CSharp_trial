namespace Assignment2.ShapeModels
{
    /// <summary>
    /// Rectangle
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets length of Rectangle.
        /// </summary>
        /// <value>
        /// Length.
        /// </value>
        public double Length { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets width of Rectangle.
        /// </summary>
        /// <value>
        /// Width.
        /// </value>
        public double Width { get; set; } = double.NaN;

        /// <summary>
        /// Gets shapes type.
        /// </summary>
        /// <value>
        /// Shapes type.
        /// </value>
        public override string ShapeType
        {
            get
            {
                return "Rectangle";
            }
        }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns>Area of the rectangle.</returns>
        public override double CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
}
