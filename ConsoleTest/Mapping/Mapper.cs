// // ------------------------------------------------------------------------
// // <copyright file="Mapper.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.Mapping;

using ConsoleTest.Interfaces;
using ConsoleTest.Mapping.Models;
using FunctionalTest.Lib;

public static class Mapper
{
    extension(Candidate src)
    {
        // Can be made internal for unit testing
        private Employee MapName() => new()
        {
            FullName = $"{src.FirstName} {src.LastName}"
        };

        // Can be made internal for unit testing
        private Employee MapAge(Employee dest) =>
            dest with { Age = src.Age };

        // Can be made internal for unit testing
        private Employee MapLocation(Employee dest) =>
            dest with { Location = src.City };

        // Can be made internal for unit testing
        private Employee GenerateEmployeeId(Employee dest, IEmployeeIdGenerator employeeIdGenerator) =>
            dest with { EmployeeId = employeeIdGenerator.GenerateEmployeeId(dest) };

        // Consider testing with snapshots
        public Employee MapToDestination(IEmployeeIdGenerator employeeIdGenerator)
        {
            Func<Candidate, Employee> doMapping =
                Functional.Pipe<Candidate, Employee>(
                    MapName,
                    src.MapAge,
                    src.MapLocation,
                    dest => src.GenerateEmployeeId(dest, employeeIdGenerator));

            return doMapping(src);
        }
    }
}
