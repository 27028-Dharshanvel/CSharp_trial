# Assignment 8: Exception Handling in C#

A clean, modular **C# console utility class** (`ExceptionHandlingTask`) demonstrating core exception handling concepts, custom user-defined exceptions, nested try-catch blocks, application-domain unhandled exception interception, and stack tracing.

---

## Features & Tasks

The `ExceptionHandlingTask` static class covers five distinct exception-handling scenarios:

1. **DivideByZeroException (`Task 1`)**  
   * Demonstrates standard arithmetic error handling.  
   * Implements a complete `try-catch-finally` block to guarantee execution of cleanup code regardless of the exception state.

2. **IndexOutOfRangeException (`Task 2`)**  
   * Demonstrates array bounds checking.  
   * Illustrates **nested try-catch blocks** by catching an array indexing fault and re-throwing/handling it with a customized message.

3. **Custom Exception (`Task 3`)**  
   * Validates console input via `int.TryParse`.  
   * Throws and catches a domain-specific custom exception (`InvalidUserInputException`) when invalid format data is provided.

4. **Unhandled Exception Interception (`Task 4`)**  
   * Hooks into `AppDomain.CurrentDomain.UnhandledException` to establish a global safety net for catching unexpected or unhandled runtime faults across the application domain.

5. **Stack Trace Analysis (`Task 5`)**  
   * Captures and displays the `StackTrace` property of an exception to examine the execution call path leading to the error.

---

## Code Reference

```csharp
namespace Assignment8
{
    internal static class ExceptionHandlingTask
    {
        public static void DemonstrateDivideByZeroException(int dividend, int divisor);
        public static void DemonstrateIndexOutOfRangeException();
        public static void DemonstrateInvalidUserInputException();
        public static void DemonstrateUnhandledException();
        public static void UnhandledExceptionMethod();
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e);
        public static void DemonstrateStackTrace();
    }
}
```

---

```csharp
using System;
using Assignment8;

namespace Assignment8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Exception Handling Demonstrations ===");

            // 1. Division by Zero
            ExceptionHandlingTask.DemonstrateDivideByZeroException(10, 0);

            // 2. Index Out of Range
            ExceptionHandlingTask.DemonstrateIndexOutOfRangeException();

            // 3. Invalid User Input (Interactive)
            // ExceptionHandlingTask.DemonstrateInvalidUserInputException();

            // 4. Global Unhandled Exception Handler
            ExceptionHandlingTask.DemonstrateUnhandledException();
            // Uncommenting the next line will trigger the global unhandled exception hook:
            // ExceptionHandlingTask.UnhandledExceptionMethod();

            // 5. Stack Trace
            ExceptionHandlingTask.DemonstrateStackTrace();
        }
    }
}
```

---
