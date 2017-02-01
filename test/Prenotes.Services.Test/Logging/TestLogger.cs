
using System;
using Microsoft.Extensions.Logging;

namespace Prenotes.Services.Test.Logging {

    public class TestLogger : ILogger {
        readonly string _name;

        readonly TestLoggerSink _sink;

        public TestLogger(string name, TestLoggerSink sink)
        {
            _name = name;
            _sink = sink;
        }
        
        public IDisposable BeginScope<TState>(TState state) => DoNothingDisposable.Instance;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _sink.AddLogRecord(new LogRecord
            {
                LogLevel = logLevel,
                EventId = eventId,
                State = state,
                Exception = exception,
                Formatter = (s, e) => formatter((TState)s, e),
                LoggerName = _name
            });
        }
    }

    public class DoNothingDisposable : IDisposable
    {
        public static readonly DoNothingDisposable Instance = new DoNothingDisposable();

        public void Dispose()
        {
        }
    }
}