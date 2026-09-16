**Memory Management in C#**

This Assignment demonstrates important memory management concepts in C# through practical examples.

**Tasks are:**

Value types and reference types
Stack and heap memory
Garbage collection
IDisposable and the using statement
Task 1: Value Types and Reference Types
Objective

To understand the difference between value types and reference types and observe how modifications behave when they are passed to methods.

The program creates a value-type variable (int) and a reference-type object (Student) and passes them to a method.


int sampleInteger = 10; 
Student student = new Student("Dharshan");
ModifyInputs(sampleInteger, student);

Value Types
Examples of value types include:

int
double
decimal
bool
struct

When a value type is passed to a method, a copy of its value is passed.

public static void ModifyInputs(int sampleInteger, Student student)
{
sampleInteger = 20;
}

Since only the copied value is modified, the original value remains unchanged.

**Reference Types**
Examples of reference types include:

class
array
List<T>
object

Reference-type variables store a reference to an object.

student.Name = "D vel";

When the object's property is modified through the copied reference, the original object is affected because both references point to the same object.

**Observation**

**Task 2: Stack and Heap Memory**

To understand how memory is allocated for value types and reference types.

**Heap Allocation**

The application allocates a large integer array using:

int[] largeArray = new int[size];

Arrays are reference types and are allocated on the managed heap.

The method:

AllocateLargeArray(10000000);

creates an array containing 10,000,000 integers.

The array is populated with values:

for (int i = 0; i < largeArray.Length; i++)
{
largeArray[i] = i * 2;
}

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

int result = (v1 + v2 + v3 + v4 + v5) * (v6 - v7 + v8 - v9 + v10);


**Task 3: Garbage Collection**
To understand how the .NET Garbage Collector reclaims memory used by unreachable managed objects.

The application simulates the allocation of a large number of objects:

**SimulateObjectChurn(10000000);**

Inside the loop, a new Student object is created during each iteration:

Student student = new Student(i);

After each iteration completes, the local variable goes out of scope and most created objects become unreachable.

Since no long-term references are maintained, these objects become eligible for garbage collection.

Monitoring Garbage Collection

Before allocation begins, the program records the current collection counts:


GC.CollectionCount(0);
GC.CollectionCount(1);
GC.CollectionCount(2);

These values represent the number of collections performed for:

Generation 0
Generation 1
Generation 2

After all objects are created, garbage collection is triggered manually:

GC.Collect();

The application then compares collection counts before and after execution.


Console.WriteLine($"Gen 0 Collections: {gc0After - gc0Before}");
Console.WriteLine($"Gen 1 Collections: {gc1After - gc1Before}");
Console.WriteLine($"Gen 2 Collections: {gc2After - gc2Before}");

The execution time is also measured using a Stopwatch:

Stopwatch stopWatch = Stopwatch.StartNew();

Millions of objects are allocated during execution.
Most objects become unreachable immediately after each loop iteration.
The Garbage Collector automatically reclaims memory for these objects.
Collection statistics can be observed using GC.CollectionCount.
Manual collection is demonstrated using GC.Collect().

In production applications, garbage collection should normally be left to the .NET runtime.

**Task 4: IDisposable and Using Statement**

To understand how IDisposable is used to release unmanaged resources and how the using statement automatically invokes Dispose().

**SimpleFileWriter Class**

The application uses a custom class named:

SimpleFileWriter
which implements the IDisposable interface.


The class internally manages a StreamWriter object:

private StreamWriter? _writer;


**Resource Management**

The constructor opens a file for writing:

_writer = new StreamWriter(filePath, append: false);

The class keeps track of whether it has been disposed:

private bool _disposed = false;

Attempting to write to a disposed writer throws an exception:


throw new ObjectDisposedException(
nameof(SimpleFileWriter),
"Cannot write to a closed file.");
Show more lines
Dispose Pattern

The public Dispose() method releases resources and suppresses finalization:

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