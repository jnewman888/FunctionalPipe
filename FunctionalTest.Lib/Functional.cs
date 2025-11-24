// // ------------------------------------------------------------------------
// // <copyright file="Functional.cs" company="Jack Henry &amp; Associates, Inc.">
// // Copyright (c) Jack Henry &amp; Associates, Inc.
// // All rights reserved.
// // </copyright>
// // ------------------------------------------------------------------------
namespace FunctionalTest.Lib;

public static class Functional
{
    // Pipe function: compose an initial function and a sequence of functions
    public static Func<TArgs, TResult> Pipe<TArgs, TResult>(Func<TArgs, TResult> fn1, params Func<TResult, TResult>[] fns)
    {
        return args => fns.Aggregate(fn1(args), (acc, fn) => fn(acc));
    }

    // Overload for multiple arguments (using tuple)
    public static Func<T1, T2, TResult> Pipe<T1, T2, TResult>(Func<T1, T2, TResult> fn1, params Func<TResult, TResult>[] fns)
    {
        return (arg1, arg2) => fns.Aggregate(fn1(arg1, arg2), (acc, fn) => fn(acc));
    }

    // More overloads can be added for more arguments as needed
}
