// // ------------------------------------------------------------------------
// // <copyright file="IEmployeeIdGenerator.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Interfaces;

using ConsoleTest.Mapping.Models;

public interface IEmployeeIdGenerator
{
    string GenerateEmployeeId(Employee employee);
}
