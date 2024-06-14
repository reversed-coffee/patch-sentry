using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PatchSentry;

public enum LogSeverity {
    Info,
    Warning,
    Error,
    Critical
}

public struct LogContext {
    public string Message;
    public int ThreadId;
    public DateTime Timestamp;
    public LogSeverity Severity;
    public string? MethodName;
}

public class LogBuildOptions {
    public bool ThreadId = true;
    public bool Timestamp = true;
    public bool Severity = true;
    public bool MethodName = true;
}

internal class Logger : IDisposable {
    readonly LogBuildOptions _buildOptions;

    public event Action<LogContext>? LogEvent;

    bool _disposed;

    public bool RetainLogs { get; set; } = true;

    readonly FileStream _logIO;

    public Logger(string logDirectory, string? logFileName = null, LogBuildOptions? buildOptions = null) {
#   if DEBUG
        logFileName ??= $"DEBUG_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
#   else
        logFileName ??= $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
#   endif
        _buildOptions = buildOptions ?? new();

        // Assert log directory
        if (!Directory.Exists(logDirectory))
            Directory.CreateDirectory(logDirectory);

        // Initialize IO
        _logIO = new(Path.Join(logDirectory, logFileName), FileMode.OpenOrCreate, FileAccess.ReadWrite,
            FileShare.Read);
    }

    public void Dispose() {
        if (_disposed)
            return;

        // Close all events
        foreach (var @delegate in LogEvent?.GetInvocationList() ?? Enumerable.Empty<Delegate>())
            LogEvent -= (Action<LogContext>)@delegate;

        // Close file
        _logIO.Close();
        if (!RetainLogs)
            File.Delete(_logIO.Name);

        _disposed = true;
    }

    string BuildLog(ref LogContext ctx, LogBuildOptions? opt = null) {
        opt ??= _buildOptions;
        var logBuilder = new StringBuilder();

        if (opt.ThreadId)
            logBuilder.Append($"[{ctx.ThreadId}] ");

        if (opt.Timestamp) {
            var fmtTimestamp = $"{ctx.Timestamp:HH:mm:ss.fff}";
            logBuilder.Append($"[{fmtTimestamp}] ");
        }

        if (opt.Severity) {
            var fmtSeverity = SeverityToString(ctx.Severity);
            logBuilder.Append($"[{fmtSeverity}] ");
        }

        if (opt.MethodName && !string.IsNullOrEmpty(ctx.MethodName) && ctx.MethodName != ".ctor")
            logBuilder.Append($"[{ctx.MethodName}] ");

        logBuilder.Append($"{ctx.Message}\n");

        return logBuilder.ToString();
    }

    static string SeverityToString(LogSeverity severity) {
        return severity switch {
            LogSeverity.Info => "INFO",
            LogSeverity.Warning => "WARNING",
            LogSeverity.Error => "ERROR",
            LogSeverity.Critical => "CRITICAL",
            _ => "???"
        };
    }

    public void Send(string message, LogSeverity severity = LogSeverity.Info) {
        var method = new StackTrace().GetFrame(1)?.GetMethod();
        Send(new() {
            Message = message,
            ThreadId = Environment.CurrentManagedThreadId,
            Timestamp = DateTime.Now,
            Severity = severity,
            MethodName = method?.Name
        });
    }

    public void Send(LogContext ctx) {
        var logMessageBytes = Encoding.UTF8.GetBytes(BuildLog(ref ctx));
        lock (_logIO) {
            _logIO.Write(logMessageBytes);
            _logIO.Flush();
        }

        LogEvent?.Invoke(ctx);
    }

    public void AttachTextBox(TextBoxBase textBox, bool loadCache = true) {
        ObjectDisposedException.ThrowIf(_disposed, typeof(Logger));

        if (loadCache)
            lock (_logIO) {
                using var reader = new StreamReader(_logIO, leaveOpen: true);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                var logCache = reader.ReadToEnd();
                reader.Close();

                textBox.Invoke(() => textBox.Text = logCache);
            }

        LogEvent += ctx =>
            textBox.Invoke(() => textBox.AppendText(BuildLog(ref ctx)));
    }
}