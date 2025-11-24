// // ------------------------------------------------------------------------
// // <copyright file="MathTest.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace ConsoleTest;

using FunctionalTest.Lib;

public class MathTest
{
    public static void Run()
    {
        // Simple transformation functions
        Func<int, int> increment = x => x + 1;
        Func<int, int> doubleValue = x => x * 2;
        Func<int, int> square = x => x * x;

        // Compose transformations using Pipe (single argument)
        Func<int, int> pipeline = Functional.Pipe(increment, doubleValue, square);
        int result = pipeline(3); // ((3 + 1) * 2)^2 = 64
        Console.WriteLine($"Result of pipeline(3): {result}");

        // Initial function with two arguments
        Func<int, int, int> add = (a, b) => a + b;
        Func<int, int, int> pipeline2 = Functional.Pipe(add, doubleValue, square);
        int result2 = pipeline2(2, 5); // ((2 + 5) * 2)^2 = 196
        Console.WriteLine($"Result of pipeline2(2, 5): {result2}");
    }
}
