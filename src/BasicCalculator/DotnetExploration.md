## 1. Key Components of the .NET Platform

* Common Language Runtime (CLR): The execution engine that handles running applications, memory management, security, and exception handling.
* Base Class Library (BCL): A comprehensive, object-oriented collection of reusable classes, types, and APIs for file I/O, strings, collections, and database access.
* Languages: Supported programming languages like C#, F#, and Visual Basic that compile down to a common intermediate format.
* Application Models / Frameworks: Specialized toolkits built on top of the BCL, such as ASP.NET Core (for web/cloud), .NET MAUI (for cross-platform mobile and desktop), and Entity Framework Core (for data access).

## 2. CLR vs. CTS

* Common Language Runtime (CLR): The virtual machine component that manages the execution of programs (e.g., JIT compilation, garbage collection, thread management).
* Common Type System (CTS): A formal specification that defines how types are declared, used, and managed in the runtime, ensuring that data types written in different .NET languages can seamlessly interoperate.

## 3. Role of the Global Assembly Cache (GAC)
The Global Assembly Cache is a machine-wide, centralized repository where strongly-named .NET assemblies are installed if they need to be shared across multiple applications on the same computer. (Note: In modern .NET Core / .NET 5+, the GAC has been largely deprecated in favor of self-contained or app-local deployment models).

## 4. Value Types vs. Reference Types in C#

| Feature          | Value Types                                 | Reference Types                              |
|------------------|---------------------------------------------|----------------------------------------------|
| Storage Location | Stack (or inline within containing objects) | Heap (with a reference pointer on the stack) |
| Assignment       | Copies the actual data value                | Copies the memory address reference          |
| Default Value    | Zero or equivalent (e.g., 0, false)         | null                                         |
| Examples         | int, bool, struct, enum                     | class, string, array, interface              |

## 5. Garbage Collection (GC) in .NET
Garbage Collection is an automatic memory manager that handles the allocation and release of memory for applications.

* Advantages: It prevents memory leaks, dangling pointers, and manual deallocation errors by periodically sweeping the managed heap to destroy objects that are no longer referenced by the application.

## 6. Globalization and Localization

* Globalization: Designing and developing an application to support multiple languages, regional formats (dates, currencies, numbers), and cultural sensibilities from the ground up.
* Localization: The subsequent process of translating and adapting that globalized application's resources (such as UI text and images) for a specific target culture or locale.

## 7. CIL and JIT Compilation
CIL (Common Intermediate Language) is the CPU-independent machine language bytecode into which source code is initially compiled. During execution, the JIT (Just-In-Time) compiler translates this CIL bytecode into native, machine-specific CPU instructions right before the code runs.


