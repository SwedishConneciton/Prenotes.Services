

using System;
using Microsoft.Extensions.Logging;

namespace Prenotes.Services.Logging {

    static class Log {

        /// <summary>
        /// Prenotes logger
        /// </summary>
        internal static readonly ILogger Logger = PrenotesLogManager.Logger;

        /// <summary>
        /// Is passed log level enabled
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static bool IsEnabled(LogLevel level) => Logger.IsEnabled(level);


        // Startup
        static readonly Action<ILogger, int, Exception> _startupConstraints = LoggerMessage
            .Define<int>(
                LogLevel.Debug, 
                PrenotesEventId.StartupConstraints, 
                "Created {CreatedConstraints} database constraints"
            );

        // Caretaker
        static readonly Action<ILogger, string, int, Exception> _confirmCaretaker = LoggerMessage
            .Define<string,int>(
                LogLevel.Information,
                PrenotesEventId.ConfirmCaretaker,
                "Confirmed {Email} having {NumberOfChildren} children"
            );

        /// <summary>
        /// Debug how many constraints got created.  The Neo4j 
        /// counter is not incremented if the constraint already existed.
        /// </summary>
        internal static void StartupConstraints(int CreatedConstraints) => _startupConstraints(Logger, CreatedConstraints, null);

        /// <summary>
        /// Information confirmation of Caretaker and the 
        /// number of child relationships
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="NumberOfChildren"></param>
        internal static void ConfirmCaretaker(string Email, int NumberOfChildren) => _confirmCaretaker(Logger, Email, NumberOfChildren, null);
    }
}