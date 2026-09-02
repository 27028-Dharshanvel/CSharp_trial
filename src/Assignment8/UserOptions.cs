using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    /// <summary>
    /// User Options.
    /// </summary>
    internal enum UserOptions
    {
        /// <summary>
        /// DivideByzeroException
        /// </summary>
        ExecuteDividebyZeroException = 1,

        /// <summary>
        /// IndexOutOfRangeException
        /// </summary>
        ExecuteIndexOutOfRangeException,

        /// <summary>
        /// InvalidUserInputException
        /// </summary>
        ExecuteInvalidUserInputException,

        /// <summary>
        /// UnhandledException
        /// </summary>
        ExecuteUnhandledException,

        /// <summary>
        /// StackTrace
        /// </summary>
        ExecuteStackTrace,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
