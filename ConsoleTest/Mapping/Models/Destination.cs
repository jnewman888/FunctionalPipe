// // ------------------------------------------------------------------------
// // <copyright file="Destination.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Mapping.Models;

public record class Destination
{
    public string FullName { get; set; }
    
    public int Age { get; set; }
    
    public string Location { get; set; }
}
