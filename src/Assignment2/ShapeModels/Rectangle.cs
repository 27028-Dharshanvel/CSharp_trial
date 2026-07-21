using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    /// <summary>
    /// Rectangle
    /// </summary>
    internal class Rectangle : Shape
    {
        public double Area { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets length of Rectangle
        /// </summary>
        /// <value>
        /// Length.
        /// </value>
        public double Length { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets width of Rectangle
        /// </summary>
        /// <value>
        /// Width.
        /// </value>
        public double Width { get; set; } = double.NaN;

        /// <summary>
        /// Gets shapes type
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
        /// Calculates area
        /// </summary>
        /// <returns>area </returns>
        public override double CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
}
