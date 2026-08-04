using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.ShapeModels
{
    /// <summary>
    /// Circle
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Gets or sets Radius.
        /// </summary>
        /// <value>
        /// Radius
        /// </value>
        public double Radius { get; set; } = double.NaN;

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
                return "Circle";
            }
        }

        /// <summary>
        /// Calculates area of the shape.
        /// </summary>
        /// <param name="Radius"> Radius </param>
        /// <returns>Area of the circle.</returns>
        public override double CalculateArea()
        {
            return 3.14 * this.Radius * this.Radius;
        }
    }
}
