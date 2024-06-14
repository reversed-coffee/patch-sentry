using System.Runtime.CompilerServices;

namespace PatchSentry.Utilities;

/// <summary>
/// Really cool stuff for exception handling. In most cases it just saves a few lines of code.
/// </summary>
public static class Except {
    /// <summary>
    /// Ensure that the condition is met, otherwise throw an exception.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Assert(bool condition, Func<Exception> exceptionFactory) {
        if (!condition)
            throw exceptionFactory();
    }

    /// <summary>
    /// Ensure that the object is not null, otherwise throw an exception.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Assert<T>(T? obj, Func<Exception> exceptionFactory) where T : class {
        if (obj is null)
            throw exceptionFactory();
        return obj;
    }
}