using ConsoleTest.Mapping;
using ConsoleTest.Mapping.Models;

var src = new Candidate
{
    FirstName = "Fred",
    LastName = "Flinstone",
    Age = 30,
    City = "New York"
};

Employee dest = src.MapToDestination();

Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");
