using Assignment2.ShapeModels;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Shape Services
    /// </summary>
    internal class ShapeServices
    {
        /// <summary>
        /// Calculates Area of the shape.
        /// </summary>
        /// <param name="shape">shape</param>
        /// <returns>Area in double value.</returns>
        public double CalculateArea(Shape shape)
        {
            return shape.CalculateArea();
        }
    }
}
