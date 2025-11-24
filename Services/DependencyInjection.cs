// // ------------------------------------------------------------------------
// // <copyright file="DependencyInjection.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace Services;

using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        return services.AddSingleton<IEmployeeService, EmployeeService>();
    }
}
