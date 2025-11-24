# Functional Pipe Testing

## The functional glue...
```csharp
public static class Functional
{
    // Pipe function: compose an initial function and a sequence of functions
    public static Func<TArgs, TResult> Pipe<TArgs, TResult>(
        Func<TArgs, TResult> fn1,
        params Func<TResult, TResult>[] fns)
    {
        return args => fns.Aggregate(fn1(args), (acc, fn) => fn(acc));
    }

    // Overload for multiple arguments (using tuple)
    public static Func<T1, T2, TResult> Pipe<T1, T2, TResult>(
        Func<T1, T2, TResult> fn1,
        params Func<TResult, TResult>[] fns)
    {
        return (arg1, arg2) => fns.Aggregate(fn1(arg1, arg2), (acc, fn) => fn(acc));
    }

    // More overloads can be added for more arguments as needed
}
```

## Model objects for testing...
```csharp
public record class Source
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public int Age { get; set; }
    
    public string City { get; set; }
}

public record class Destination
{
    public string FullName { get; set; }
    
    public int Age { get; set; }
    
    public string Location { get; set; }
}
```

## Mapping...
```csharp
    private static Destination MapName(this Source src) => new()
    {
        FullName = $"{src.FirstName} {src.LastName}"
    };

    private static Destination MapAge(this Source src, Destination dest) =>
        dest with { Age = src.Age };

    private static Destination MapLocation(this Source src, Destination dest) =>
        dest with { Location = src.City };
    
    private static Destination MapToDestination(this Source source)
    {
        Func<Source, Destination> doMapping = 
            Functional.Pipe<Source, Destination>(
                MapName,
                source.MapAge,
                source.MapLocation);

        return doMapping(source);
    }
```
