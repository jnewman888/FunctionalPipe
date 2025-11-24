// // ------------------------------------------------------------------------
// // <copyright file="MapperTests.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest.UnitTests;

using ConsoleTest.Mapping;
using Models;
using Services;
using Services.Interfaces;

public class MappingsTests
{
    private readonly IEmployeeService _employeeService = new EmployeeService();

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
        Employee employee = candidate.MapToEmployee(this._employeeService);

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
        Employee employee1 = candidate.MapToEmployee(this._employeeService);
        Employee employee2 = candidate.MapToEmployee(this._employeeService);

        // Assert
        Assert.NotEqual(employee1.EmployeeId, employee2.EmployeeId);
    }
}
