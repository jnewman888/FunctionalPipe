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
    private static Destination MapName(this Source src) => new()
    {
        FullName = $"{src.FirstName} {src.LastName}"
    };

    private static Destination MapAge(this Source src, Destination dest) => dest with { Age = src.Age };

    private static Destination MapLocation(this Source src, Destination dest) => dest with { Location = src.City };
    
    private static Destination MapToDestination(this Source source)
    {
        Func<Source, Destination> doMapping = Functional.Pipe<Source, Destination>(
            MapName,
            source.MapAge,
            source.MapLocation);

        return doMapping(source);
    }
    
    public static void Run()
    {
        var src = new Source { FirstName = "Fred", LastName = "Flinstone", Age = 30, City = "New York" };

        Destination dest = MapToDestination(src);

        Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");        
    }
}
