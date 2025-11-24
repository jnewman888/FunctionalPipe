// // ------------------------------------------------------------------------
// // <copyright file="Mapper.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace HelloDotNet10.Mapping;

using FunctionalTest.Lib;
using HelloDotNet10.Mapping.Models;

public static class Mapper
{
    private static Destination MapToDestination(this Source source)
    {
        Func<Source, Destination> doMapping = Functional.Pipe<Source, Destination>(
            s => new Destination() { FullName = s.Name },
            d => { d.Age = source.Age; return d; },
            d => { d.Location = source.City; return d; });

        return doMapping(source);
    }
    
    public static void Run()
    {
        var src = new Source { Name = "Fred Flinstone", Age = 30, City = "New York" };

        Destination dest = MapToDestination(src);

        Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");        
    }
}
