Memory Management in C#
Overview

This Assignment demonstrates important memory management concepts in C# through practical examples.

Tasks are:

Value types and reference types
Stack and heap memory
Garbage collection
IDisposable and the using statement
Task 1: Value Types and Reference Types
Objective

To understand the difference between value types and reference types and observe how modifications behave when they are passed to methods.

The program creates a value-type variable (int) and a reference-type object (Student) and passes them to a method.

C#
1
int sampleInteger = 10;
2
Student student = new Student("Dharshan");
3
 
4
ModifyInputs(sampleInteger, student);
Show more lines
Value Types

Examples of value types include:

int
double
decimal
bool
struct

When a value type is passed to a method, a copy of its value is passed.

C#
1
public static void ModifyInputs(int sampleInteger, Student student)
2
{
3
sampleInteger = 20;
4
}
Show more lines

Since only the copied value is modified, the original value remains unchanged.

Reference Types

Examples of reference types include:

class
array
List<T>
object

Reference-type variables store a reference to an object.

C#
1
student.Name = "D vel";
Show more lines

When the object's property is modified through the copied reference, the original object is affected because both references point to the same object.

Observation
Value Type	Reference TypeStores the actual value	Stores a reference to an object
A copy of the value is passed	A copy of the reference is passed
Modifying the parameter does not affect the original variable	Modifying object members affects the original object
Examples: int, double, struct	Examples: class, array, List<T>
Task 2: Stack and Heap Memory
Objective

To understand how memory is allocated for value types and reference types.

Heap Allocation

The application allocates a large integer array using:

C#
1
int[] largeArray = new int[size];
Show more lines

Arrays are reference types and are allocated on the managed heap.

The method:

C#
1
AllocateLargeArray(10000000);
Show more lines

creates an array containing 10,000,000 integers.

The array is populated with values:

C#
1
for (int i = 0; i < largeArray.Length; i++)
2
{
3
largeArray[i] = i * 2;
4
}
Show more lines

The program then calculates the sum of all elements.

Because the array is stored on the managed heap, significant memory usage can be observed through Visual Studio Diagnostic Tools or similar memory profilers.

Local Value-Type Calculation

The application also performs calculations using local integer variables:

C#
1
int v1 = 10, v2 = 20, v3 = 30, v4 = 40, v5 = 50;
2
int v6 = 60, v7 = 70, v8 = 80, v9 = 90, v10 = 100;
Show more lines

These variables are value types and their values are stored directly within the method's stack frame.

The calculation performed is:

C#
1
int result = (v1 + v2 + v3 + v4 + v5) * (v6 - v7 + v8 - v9 + v10);
Show more lines
Observation
Stack Memory	Heap MemoryStores local value-type variables	Stores objects and arrays
Automatically released when method exits	Managed by the Garbage Collector
Fast allocation and deallocation	Supports dynamic memory allocation
Example: local int variables	Example: int[], Student objects
Task 3: Garbage Collection
Objective

To understand how the .NET Garbage Collector reclaims memory used by unreachable managed objects.

The application simulates the allocation of a large number of objects:

C#
1
SimulateObjectChurn(10000000);
Show more lines

Inside the loop, a new Student object is created during each iteration:

C#
1
Student student = new Student(i);
Show more lines

After each iteration completes, the local variable goes out of scope and most created objects become unreachable.

Since no long-term references are maintained, these objects become eligible for garbage collection.

Monitoring Garbage Collection

Before allocation begins, the program records the current collection counts:

C#
1
GC.CollectionCount(0);
2
GC.CollectionCount(1);
3
GC.CollectionCount(2);
Show more lines

These values represent the number of collections performed for:

Generation 0
Generation 1
Generation 2

After all objects are created, garbage collection is triggered manually:

C#
1
GC.Collect();
Show more lines

The application then compares collection counts before and after execution.

C#
1
Console.WriteLine($"Gen 0 Collections: {gc0After - gc0Before}");
2
Console.WriteLine($"Gen 1 Collections: {gc1After - gc1Before}");
3
Console.WriteLine($"Gen 2 Collections: {gc2After - gc2Before}");
Show more lines

The execution time is also measured using a Stopwatch:

C#
1
Stopwatch stopWatch = Stopwatch.StartNew();
Show more lines
Observation
Millions of objects are allocated during execution.
Most objects become unreachable immediately after each loop iteration.
The Garbage Collector automatically reclaims memory for these objects.
Collection statistics can be observed using GC.CollectionCount.
Manual collection is demonstrated using GC.Collect().
In production applications, garbage collection should normally be left to the .NET runtime.
Task 4: IDisposable and Using Statement
Objective

To understand how IDisposable is used to release unmanaged resources and how the using statement automatically invokes Dispose().

SimpleFileWriter Class

The application uses a custom class named:

C#
1
SimpleFileWriter
Show more lines

which implements the IDisposable interface.

C#
1
internal class SimpleFileWriter : IDisposable
2
{
3
}
Show more lines

The class internally manages a StreamWriter object:

C#
1
private StreamWriter? _writer;
Show more lines
Resource Management

The constructor opens a file for writing:

C#
1
_writer = new StreamWriter(filePath, append: false);
Show more lines

Data can be written using:

C#
1
WriteLine("Sample Text");
Show more lines

The class keeps track of whether it has been disposed:

C#
1
private bool _disposed = false;
Show more lines

Attempting to write to a disposed writer throws an exception:

C#
1
throw new ObjectDisposedException(
2
nameof(SimpleFileWriter),
3
"Cannot write to a closed file.");
Show more lines
Dispose Pattern

The public Dispose() method releases resources and suppresses finalization:

C#
1
public void Dispose()
2
{
3
Dispose(true);
4
GC.SuppressFinalize(this);
5
}
Show more lines

The actual cleanup logic is performed in:

C#
1
protected virtual void Dispose(bool disposing)
Show more lines

where the StreamWriter is disposed:

C#
1
_writer.Dispose();
2
_writer = null;
Show more lines

and the object is marked as disposed:

C#
1
_disposed = true;
Show more lines
Using Statement

The class can be used with a using statement:

C#
1
using (SimpleFileWriter writer =
2
new SimpleFileWriter("sample.txt"))
3
{
4
writer.WriteLine("Hello World");
5
}
Show more lines

When execution leaves the using block:

Dispose() is automatically called.
The StreamWriter is closed.
File resources are released.
The file can be safely accessed by other parts of the application.
Observation
Without using	With usingDeveloper must explicitly call Dispose()	Dispose() is called automatically
Greater risk of resource leaks	Ensures proper resource cleanup
More error-prone during exceptions	Cleanup occurs even when exceptions are thrown
Resources may remain open longer	Resources are released as soon as the block ends
Conclusion

This assignment demonstrates key memory-management concepts in C#:

Value types store data directly, while reference types store references to objects.
Local value-type variables are typically stored within stack frames, whereas arrays and objects are allocated on the managed heap.
The .NET Garbage Collector automatically reclaims memory occupied by unreachable objects.
IDisposable provides a deterministic way to release resources, and the using statement ensures that Dispose() is called automatically.