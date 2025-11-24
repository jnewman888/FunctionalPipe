// // ------------------------------------------------------------------------
// // <copyright file="Destination.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace Models;

public record class Employee
{
    public required string EmployeeId { get; set; }

    public required string FullName { get; set; }

    public required int Age { get; set; }

    public required string Location { get; set; }
}
