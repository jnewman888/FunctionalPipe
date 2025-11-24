// // ------------------------------------------------------------------------
// // <copyright file="Mapper.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Mapping;

using ConsoleTest.Mapping.Models;
using FunctionalTest.Lib;

public static class Mapper
{
    private static Employee MapName(this Candidate src) => new()
    {
        FullName = $"{src.FirstName} {src.LastName}"
    };

    private static Employee MapAge(this Candidate src, Employee dest) =>
        dest with { Age = src.Age };

    private static Employee MapLocation(this Candidate src, Employee dest) =>
        dest with { Location = src.City };
    
    private static Employee GenerateEmployeeId(this Candidate src, Employee dest) =>
        dest with { EmployeeId = Guid.NewGuid().ToString() };

    private static Employee MapToDestination(this Candidate candidate)
    {
        Func<Candidate, Employee> doMapping = 
            Functional.Pipe<Candidate, Employee>(
                MapName,
                candidate.MapAge,
                candidate.MapLocation,
                candidate.GenerateEmployeeId);

        return doMapping(candidate);
    }
    
    public static void Run()
    {
        var src = new Candidate
        {
            FirstName = "Fred",
            LastName = "Flinstone",
            Age = 30,
            City = "New York"
        };

        Employee dest = MapToDestination(src);

        Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");        
    }
}
