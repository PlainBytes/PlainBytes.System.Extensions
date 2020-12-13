<img src="https://github.com/BriskBytes/BriskBytes.System.Extensions/blob/master/assets/system-extensions.png?raw=true" width="240">

# System.Extensions

Collection of extension method for the BCL to ease their usage.

# Examples

## Accessing an index

There are many occasions when the size of the collection or the index that we want to access is unknown, for that we can use.

```csharp
    if (collection.HasIndex(index))
    {
        // access index
    }
```
Or we could just do the following:

```csharp
    collection.AtIndexOrDefault(index);

    //Or even provide a fallback 
    collection.AtIndexOrFallback(index, fallBackValue);
```

## Iterators

Simple For and Select extension for ILists

```csharp
    collection.For((index, value) =>
    {
        // do
    });

    var results =  collection.SelectWithIndex(index =>
    {
        // do

        // return value
    });
```

Simple ForEach and filter by type for IEnumerable
```csharp
    collection.SelectTypeOf<string>().Foreach(value =>
    {
        // do
    });
```

## Simple extensions

### double
System extensions
```csharp
    value.IsNaN();
    value.IsInfinity();
    // etc...
```
Clamp (int or double), inspired by the css clamp method
```csharp
    value.Clamp(min,max) 
```
### string
System extensions and their negated counterparts (ok flow).
```csharp
    value.IsNullOrEmpty();
    // negated
    value.HasValue();

    value.IsNullOrWhiteSpace();
    // negated
    value.HasActualValue();
    
    value.FormatWith(args); // Formats value with args
```


# Install

## Package manger

    Install-Package PlainBytes.System.Extensions

## CLI

    dotnet add package PlainBytes.System.Extensions

Target platform: [.Net Standard 1.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) and above.
