using System.Diagnostics;

namespace PatchSentry;

internal class ProgramState {
    public class NothingClass { }
    public static readonly NothingClass Nothing = new(); // Literally just a placeholder for nothing

    readonly Dictionary<string, object?> _cache = new();
    
    public string LocalFiles { get; }

    public Logger Logger { get; }

    public ProgramState() {
        // Get local files path
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        LocalFiles = Path.Combine(desktopPath, "PatchSentry");

        // Assert local files
        if (!Directory.Exists(LocalFiles))
            Directory.CreateDirectory(LocalFiles);

        // Initialize logger
        Logger = new(Path.Join(LocalFiles, "logs")) {
#       if DEBUG
            RetainLogs = false
#       endif
        };
        Logger.Send("Initialized logger");

        // Clean up on program exit
        AppDomain.CurrentDomain.ProcessExit += Cleanup;

#   if !DEBUG
        // Delegate unhandled exceptions
        Application.ThreadException += DelegateThreadException;
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        AppDomain.CurrentDomain.UnhandledException += DelegateUnhandledException;
#   endif
    }

    static void UnhandledExceptionExit() {
        MessageBox.Show(@"An unhandled exception occurred. Please check the logs for more information.",
            @"Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Environment.Exit(1000);
    }

    void DelegateThreadException(object? sender, ThreadExceptionEventArgs e) {
        Logger.Send($"Unhandled exception (thread): {e.Exception}");
        Cleanup(sender, e);
        UnhandledExceptionExit();
    }

    void DelegateUnhandledException(object? sender, UnhandledExceptionEventArgs e) {
        Logger.Send($"Unhandled exception (domain): {e.ExceptionObject}");
        Cleanup(sender, e);
        UnhandledExceptionExit();
    }

    void Cleanup(object? sender, EventArgs e) {
        Logger.Dispose();
    }

    public object? this[string key] {
        get {
            var success = _cache.TryGetValue(key, out var value);
            return success ? value : Nothing;
        }
        set => _cache[key] = value;
    }

    public bool Exists(string key) => _cache.ContainsKey(key);

    public T? Get<T>(string key, out bool exists) where T : class {
        exists = _cache.TryGetValue(key, out var value);
        return exists ? value as T : null;
    }

    public T? Get<T>(string key, T? defaultValue) where T : class {
        var success = _cache.TryGetValue(key, out var value);
        return success ? value as T : defaultValue;
    }

    public void Set<T>(string key, T? value) where T : class =>
        _cache[key] = value;

    public void Set<T>(string key, T? value, T defaultValue) where T : class =>
        _cache[key] = value ?? defaultValue;

    public T? GetOrSet<T>(string key, Func<T>? ctor = null) where T : class {
        var success = _cache.TryGetValue(key, out var value);
        if (!success)
            _cache[key] = value = ctor?.Invoke();
        return value as T;
    }
}