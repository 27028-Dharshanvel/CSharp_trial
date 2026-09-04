## 1.What is .NET Platform?
     
  The .NET platform is an open-source, cross-platform, and software development platform created by Microsoft for building a wide variety of applications, including web, mobile, desktop, cloud, gaming, and Internet of Things (IoT) solutions. Its primary purpose is to provide a consistent, high-performance, and unified programming environment where developers can write code in multiple languages (such as C#, F#, and Visual Basic) and run it seamlessly across different operating systems like Windows, macOS, and Linux.
  Why is .NET prefered : 
     * Memory managemnet - .NET's Garbage collector automatically manages unused memory.
     * Ready-made libraries - .NET provides libraries for files, JSON, Networking, etc...

## 1. Key Components of the .NET Platform

* Common Language Runtime (CLR): The execution engine that handles running applications, memory management, security, and exception handling.
* Framework Class Library: The .NET Framework Class Library (FCL) is a collection of pre-built functions and classes available to developers. The FCL provides a range of namespaces that contain classes for tasks like File I/O, Networking, Database access, etc..
* Base Class Library (BCL): A comprehensive, object-oriented collection of reusable classes, types, and APIs for file I/O, strings, collections, and database access.
* Common Type System: A system which defines how data types are declared, used, and managed in memory. It ensures objects written in different languages could interact.
* Languages: Supported programming languages like C#, F#, and Visual Basic that compile down to a common intermediate format.
* Application Models / Frameworks: Specialized toolkits built on top of the BCL, such as ASP.NET Core (for web/cloud), .NET MAUI (for cross-platform mobile and desktop), and Entity Framework Core (for data access).

## 2. CLR vs. CTS

| Feature       | Common Language Runtime    | Common Type System     |
|---------------|----------------------------|------------------------|
|Nature |Software implementation (a virtual machine execution engine).| Formal specification and standard ruleset.|
|Purpose | Memory management, thread execution, JIT compilation, security, and garbage collection.| Enforcing a unified type system across different .NET languages (e.g., C#, F#).|
|Execution | It is the runtime where the apllication gets executed. | It is used during compilation and enforced by CLR at runtime.|

   The primary difference between CLR (Common Language Runtime) and CTS (Common Type System) is that the CLR is the active execution engine that runs, manages, and executes .NET applications, whereas the CTS is a theoretical specification and rulebook that defines how data types must be declared, used, and managed so that different languages can understand each other.

## 3. Role of the Global Assembly Cache (GAC)
The Global Assembly Cache is a machine-wide, centralized repository where strongly-named .NET assemblies are installed if they need to be shared across multiple applications on the same computer. 
Key Features :
* Global Sharing: Centralizes assemblies so multiple applications on the machine can share them without file duplication.
* Side-by-Side Versioning: Allows multiple versions of the same assembly to coexist without version conflicts.
* Strong Naming: Requires assemblies to have a unique cryptographic strong name for identity and integrity verification.
* Admin Security: Resides in a protected system directory, requiring administrator privileges to install or modify files.
* CLR Priority: Checked first by the Common Language Runtime during application dependency resolution.

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


