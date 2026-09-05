using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Student class
    /// </summary>
    internal class Student
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// Student
        /// </summary>
        /// <param name="name">name</param>
        public Student(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string? Name { get; set; }
    }
}
