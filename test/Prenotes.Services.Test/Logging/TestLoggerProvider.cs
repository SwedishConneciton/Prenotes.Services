
using Microsoft.Extensions.Logging;

namespace Prenotes.Services.Test.Logging {

    public class TestLoggerProvider : ILoggerProvider
    {
        readonly TestLoggerSink _sink;

        public TestLoggerProvider(TestLoggerSink sink)
        {
            _sink = sink;
        }

        public ILogger CreateLogger(string name) => new TestLogger(name, _sink);
        
        public void Dispose() {}
    }
}