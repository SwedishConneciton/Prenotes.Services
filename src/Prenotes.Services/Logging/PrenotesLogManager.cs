using Microsoft.Extensions.Logging;

namespace Prenotes.Services.Logging
{

    public static class PrenotesLogManager {
        static bool _accessedFactory;

        static ILoggerFactory _factory;

        static ILogger _prenotesLogger;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ILogger</returns>
        internal static ILogger Logger => _prenotesLogger ?? (_prenotesLogger = _factory.CreateLogger("Prenotes"));

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ILoggerFactory</returns>
        public static ILoggerFactory LoggerFactory
        {
            get
            {
                _accessedFactory = true;
                return _factory;
            }

            set
            {
                if (_accessedFactory) {

                }

                _factory = value;
            }
        }

        static PrenotesLogManager()
        {
            LoggerFactory = new LoggerFactory();
        }
    }
}