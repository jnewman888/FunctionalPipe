using ConsoleTest.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;
using Services.Interfaces;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddMyServices()
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
