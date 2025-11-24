using ConsoleTest.Mapping;
using ConsoleTest.Mapping.Models;
using ConsoleTest.Services;

var src = new Candidate
{
    FirstName = "Fred",
    LastName = "Flinstone",
    Age = 30,
    City = "New York"
};

Employee dest = src.MapToDestination(new EmployeeIdGenerator());

Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");
