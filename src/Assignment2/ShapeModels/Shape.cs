using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    /// <summary>
    /// Shape
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets colour
        /// </summary>
        /// <value>
        /// Gets or sets colour.
        /// </value>
        public string Colour { get; set; } = string.Empty;

        /// <summary>
        /// Gets shapeType
        /// </summary>
        /// <value>
        /// string 
        /// </value>
        public abstract string ShapeType { get; } = string.Empty;

        /// <summary>
        /// Calculates area
        /// </summary>
        /// <returns>Area in double </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Displays shape details
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine("Color of the shape : ", this.Colour);
            Console.WriteLine("Area of the shape : ", this.CalculateArea());
        }
    }
}
