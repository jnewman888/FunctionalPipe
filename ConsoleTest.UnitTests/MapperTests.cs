// // ------------------------------------------------------------------------
// // <copyright file="MapperTests.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.UnitTests;

using ConsoleTest.Interfaces;
using ConsoleTest.Mapping;
using ConsoleTest.Mapping.Models;
using ConsoleTest.Services;

public class MapperTests
{
    private readonly IEmployeeIdGenerator employeeIdGenerator = new EmployeeIdGenerator();

    [Fact]
    public void MapToDestination_MapsAllPropertiesCorrectly()
    {
        // Arrange
        var candidate = new Candidate
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            City = "New York"
        };

        // Act
        Employee employee = candidate.MapToDestination(this.employeeIdGenerator);

        // Assert
        Assert.Equal("John Doe", employee.FullName);
        Assert.Equal(30, employee.Age);
        Assert.Equal("New York", employee.Location);
        Assert.False(string.IsNullOrWhiteSpace(employee.EmployeeId));
    }

    [Fact]
    public void MapToDestination_EmployeeIdIsUnique()
    {
        // Arrange
        var candidate = new Candidate
        {
            FirstName = "Jane",
            LastName = "Smith",
            Age = 25,
            City = "Chicago"
        };

        // Act
        Employee employee1 = candidate.MapToDestination(this.employeeIdGenerator);
        Employee employee2 = candidate.MapToDestination(this.employeeIdGenerator);

        // Assert
        Assert.NotEqual(employee1.EmployeeId, employee2.EmployeeId);
    }
}
