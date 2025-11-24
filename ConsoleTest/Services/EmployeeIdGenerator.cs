// // ------------------------------------------------------------------------
// // <copyright file="EmployeeIdGenerator.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Services;

using ConsoleTest.Interfaces;
using ConsoleTest.Mapping.Models;

public class EmployeeIdGenerator : IEmployeeIdGenerator
{
    public string GenerateEmployeeId(Employee employee) => Guid.NewGuid().ToString("N");
}