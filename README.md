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
public class Source
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Destination
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Location { get; set; }
}
```

## Mapping...
```csharp
private static Destination MapToDestination(this Source source)
{
    Func<Source, Destination> doMapping = Functional.Pipe<Source, Destination>(
        s => new Destination() { FullName = $"{s.FirstName} {s.LastName}" },
        d => { d.Age = source.Age; return d; },
        d => { d.Location = source.City; return d; });

    return doMapping(source);
}
```
