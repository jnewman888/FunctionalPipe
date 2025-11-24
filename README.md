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

## Models for testing...

```csharp
public record class Candidate
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public int Age { get; set; }
    
    public string City { get; set; }
}

public record class Employee
{
    public string EmployeeId { get; set; }

    public string FullName { get; set; }
    
    public int Age { get; set; }
    
    public string Location { get; set; }
}
```

## Mapping...

```csharp
public static class Mapper
{
    extension(Candidate src)
    {
        // Can be made internal for unit testing
        private Employee MapName() => new()
        {
            FullName = $"{src.FirstName} {src.LastName}"
        };

        // Can be made internal for unit testing
        private Employee MapAge(Employee dest) =>
            dest with { Age = src.Age };

        // Can be made internal for unit testing
        private Employee MapLocation(Employee dest) =>
            dest with { Location = src.City };

        // Can be made internal for unit testing
        private Employee GenerateEmployeeId(Employee dest) =>
            dest with { EmployeeId = Guid.NewGuid().ToString() };

        // Consider testing with snapshots
        public Employee MapToDestination()
        {
            Func<Candidate, Employee> doMapping = 
                Functional.Pipe<Candidate, Employee>(
                    MapName,
                    src.MapAge,
                    src.MapLocation,
                    src.GenerateEmployeeId);

            return doMapping(src);
        }
    }
}
```

## Usage...

```csharp
var src = new Candidate
{
    FirstName = "Fred",
    LastName = "Flinstone",
    Age = 30,
    City = "New York"
};

Employee dest = src.MapToDestination();

Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");
```
