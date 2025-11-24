// // ------------------------------------------------------------------------
// // <copyright file="Mapper.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Mapping;

using ConsoleTest.Interfaces;
using ConsoleTest.Mapping.Models;

public static class Mappings
{
    extension(Candidate src)
    {
        public Employee MapToEmployee(IEmployeeService employeeService)
        {
            return new()
            {
                FullName = $"{src.FirstName} {src.LastName}",
                Age = src.Age,
                Location = src.City,
                EmployeeId = employeeService.GenerateEmployeeId()
            };
        }
    }
}
