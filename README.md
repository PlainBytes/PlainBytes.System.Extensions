<p align="center">
    <img width="128" align="center" src="assets/system-extensions.png" >
</p>

<h1 align="center">
  System.Extensions
</h1>

<p align="center">
 Collection of extension method for the BCL to ease their usage. Please feel free to submit bits that are not yet included.
</p>

[![GitHub](https://img.shields.io/github/license/PlainBytes/PlainBytes.System.Extensions)](https://github.com/PlainBytes/PlainBytes.System.Extensions/blob/master/LICENSE) [![Nuget](https://img.shields.io/nuget/dt/PlainBytes.System.Extensions)](https://www.nuget.org/packages/PlainBytes.System.Extensions/) ![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/PlainBytes/PlainBytes.System.Extensions/master)[![Build Validation](https://github.com/PlainBytes/PlainBytes.System.Extensions/actions/workflows/build.yml/badge.svg)](https://github.com/PlainBytes/PlainBytes.System.Extensions/actions/workflows/build.yml)
<p align="center">
 
</p>

## Examples
### String
```csharp
     var stringValue = "text";

    _ = stringValue.IsNullOrEmpty();
    _ = stringValue.IsNullOrWhiteSpace();

    _ = stringValue.HasValue();
    _ = stringValue.HasActualValue();

    _ = "{0} {1}".FormatWith(1, 2);
```
### Numeric types
```csharp

    // Int, uint, long, ulong, byte
    var number = 123;

    _ = intValue.Clamp(0, 100);
    _ = intValue.ToBool(); // each type has its revers bool to number.
```
### Double
```csharp
    var doubleValue = 12.34;

    _ = doubleValue.Clamp(0, 100);
    _ = doubleValue.IsInfinity();
    _ = doubleValue.IsNegativeInfinity();
    _ = doubleValue.IsPositiveInfinity();
    _ = doubleValue.IsNaN();
    _ = doubleValue.IsEqual(34.12,tolerance: 0.1); //two NaNs are also evaluated as equals
```

### Collection access
```csharp
    var collection = new[] {1, 2, 3};
    
    _ = collection.HasIndex(4);
    _ = collection.AtIndexOrDefault(4);
    _ = collection.AtIndexOrFallback(4, -1);
    _ = collection.IsEmpty();

    var directory = new Dictionary<int, int>();

    _ = directory.AtKeyOrFallback(4, -1);
```
### Iterators
```csharp
    // Extensions for IList<T>, IEnumerable<T> and Enumerable

    var collection = new[] {1, 2, 3};

    collection.For((index, value) => {});
    collection.ForEach(value => {});

    _ = collection.SelectWithIndex((index, value) => value);
    _ = collection.SelectTypeOf<double>();

    var secondCollection = new[] {4, 5};

    _ = collection.Append(secondCollection);
```

## Install

### Package manger

    Install-Package PlainBytes.System.Extensions

### CLI

    dotnet add package PlainBytes.System.Extensions
