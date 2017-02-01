
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Neo4j.Driver.V1;
using Prenotes.Services.Exceptions;
using Prenotes.Services.Things;

namespace Prenotes.Services {

    public static class Utils {

        private static Random Counter = new Random();

        /// <summary>
        /// Simple random code generator
        /// </summary>
        /// <returns>6 character code</returns>
        public static string NextCode () {
            return Counter.Next().As<string>().Substring(0,6);
        }

        /// <summary>
        /// Net Guid generator intended for Notifications
        /// </summary>
        /// <returns></returns>
        public static string WhoAmI() {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Unix epoch as integer
        /// </summary>
        /// <returns></returns>
        public static int Epoch() {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        /// <summary>
        /// Wrap any validation failures in a custom exception
        /// </summary>
        /// <param name="results"></param>
        public static void MaybeExplode (this ValidationResult results) {
            if (!results.IsValid) {
                throw new ValidationException(results.Errors.First().ErrorMessage);
            }
        }

        /// <summary>
        /// Map IRecord to a Caretaker with following 
        /// structure:
        ///    "caretaker" => INode
        ///    "children" => List<INode> 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static Caretaker ToCaretaker(this IRecord record) {
            INode c = record["caretaker"]
                .As<INode>();
            INode[] kids = record["children"]
                .As<List<INode>>()
                .ToArray();

            return new Caretaker(
                c.Properties["email"].As<string>(),
                c.Properties["created"].As<int>(),
                c.Properties.ContainsKey("name") ? c.Properties["name"].As<string>() : null,
                kids?
                    .Select(
                        x => new Child(
                            x.Properties["name"].As<string>(),
                            x.Properties.ContainsKey("nickname") ? x.Properties["nickname"].As<string>() : null,
                            x.Properties["created"].As<int>(),
                            null,
                            null
                        )
                    )
                    .ToArray()
            );
        }
    }
}