// // ------------------------------------------------------------------------
// // <copyright file="EmployeeService.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Services;

using ConsoleTest.Interfaces;

public class EmployeeService : IEmployeeService
{
    public string GenerateEmployeeId() => Guid.NewGuid().ToString("N");
}