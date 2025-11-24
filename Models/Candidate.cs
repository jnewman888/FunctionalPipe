// // ------------------------------------------------------------------------
// // <copyright file="Source.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace Models;

public record class Candidate
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required int Age { get; set; }

    public required string City { get; set; }
}
