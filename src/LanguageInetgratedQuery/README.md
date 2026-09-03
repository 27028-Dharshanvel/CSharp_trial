# Language Integrated Query (LINQ) Tasks Documentation

This document provides a comprehensive breakdown and technical guide for the LINQ (`LanguageIntegratedQuery`) tasks implemented.

---

## Overview

The `LinqTask` class demonstrates various levels of LINQ capabilities in C#, ranging from basic filtering and projections to complex grouping, inner joins, advanced numerical manipulations, performance optimization, and the Fluent API design pattern.

---

## Task Breakdown

### Task 1: Basic LINQ Queries (`ExecuteBasicLinqTask`)
Demonstrates fundamental LINQ operations such as filtering, projection, ordering, and aggregation on a collection of `Product` objects.

* **Filtering (`Where`)**: Filters products belonging to the `"Electronics"` category with a price greater than `500`.
* **Projection (`Select`)**: Projects the filtered results into an anonymous type containing only `ProductName` and `ProductPrice`.
* **Ordering (`OrderByDescending`)**: Sorts the projected products in descending order based on their price.
* **Aggregation (`Average`)**: Computes the average price of the filtered electronic products.

```csharp
var products1 = products
    .Where(p => p.ProductCategory == "Electronics" && p.ProductPrice > 500)
    .Select(p => new { p.ProductName, p.ProductPrice })
    .ToList();

var products2 = products1.OrderByDescending(p => p.ProductPrice).ToList();
decimal average = products1.Average(p => p.ProductPrice);
```

---

### Task 2: Complex LINQ Queries (`ExecuteIntermediateLinqTask`)
Covers grouping, nested ordering, and relational joins.

* **Grouping (`GroupBy`)**: Groups products by `ProductCategory`. For each group, it calculates the total count and extracts the most expensive product using `OrderByDescending().First()`.
* **Relational Join (`Join`)**: Performs an inner join between `Product` and `Supplier` collections using `ProductId` as the foreign/primary key relation.

```csharp
var products3 = products
    .GroupBy(p => p.ProductCategory)
    .Select(group => new {
        Category = group.Key,
        ProductCount = group.Count(),
        MostExpensiveProduct = group.OrderByDescending(p => p.ProductPrice).First()
    })
    .ToList();

var productSuppliers = products
    .Join(suppliers,
          product => product.ProductId,
          supplier => supplier.ProductId,
          (product, supplier) => new {
              product.ProductId,
              product.ProductName,
              product.ProductCategory,
              product.ProductPrice,
              supplier.SupplierName
          })
    .ToList();
```

---

### Task 3: LINQ to Objects (`ExecuteAdvancedLinqTask`)
Performs complex algorithmic and mathematical operations on integer arrays.

* **Second Highest Number**: Uses `Distinct()` to remove duplicates, sorts descending, `Skip(1)` to bypass the highest value, and takes the next element (`First()`).
* **Pair Sum Matching**: Uses indexed `SelectMany` to locate unique pairs of numbers in the array whose sum equals a specified target (`10`).

```csharp
int secondHighest = numbers
    .Distinct()
    .OrderByDescending(number => number)
    .Skip(1)
    .First();

var pairs = numbers.SelectMany((number, index) =>
    numbers.Skip(index + 1)
           .Where(secondNumber => number + secondNumber == target)
           .Select(secondNumber => new { FirstNumber = number, SecondNumber = secondNumber })
).ToList();
```

---

### Task 4: Performance Considerations (`ExecuteOptimizedLinqTask`)
Highlights best practices regarding memory overhead and projection timing.

* **Unoptimized vs. Optimized**: Demonstrates selecting specific columns (`Select`) after filtering and sorting, or evaluating full entity retrieval versus lightweight projections.

```csharp
var optimizedBooks = products
    .Where(p => p.ProductCategory == "Books")
    .OrderBy(p => p.ProductPrice)
    .Select(p => new { p.ProductName, p.ProductPrice })
    .ToList();
```

---

### Task 5: Fluent API Pattern (`ExecuteFluentApiPattern`)
Demonstrates encapsulation of LINQ queries inside a custom fluent `QueryBuilder<T>` wrapper class to chain criteria cleanly.

```csharp
var queryBuilder = new QueryBuilder<Product>(products);
var result = queryBuilder
    .Filter(p => p.ProductPrice > 500)
    .SortBy(p => p.ProductName)
    .Execute();