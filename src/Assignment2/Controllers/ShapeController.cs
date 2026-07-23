using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.ShapeModels;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Shape Controller
    /// </summary>
    internal class ShapeController
    {
        /// <summary>
        /// Calculates Area
        /// </summary>
        /// <param name="shape">shape</param>
        /// <returns>area</returns>
        public double CalculateArea(Shape shape)
        {
            return shape.CalculateArea();
        }
    }
}
