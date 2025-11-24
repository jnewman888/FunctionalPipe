using ConsoleTest.Interfaces;
using ConsoleTest.Mapping;
using ConsoleTest.Mapping.Models;
using ConsoleTest.Services;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<IEmployeeService, EmployeeService>()
    .BuildServiceProvider();

var src = new Candidate
{
    FirstName = "Fred",
    LastName = "Flinstone",
    Age = 30,
    City = "New York"
};

Employee dest = src.MapToEmployee(
    serviceProvider.GetRequiredService<IEmployeeService>());

Console.WriteLine($"FullName: {dest.FullName}, Age: {dest.Age}, Location: {dest.Location}");
