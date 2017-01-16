
using System;
using System.Linq;
using FluentValidation.Results;
using Prenotes.Services.Exceptions;

namespace Prenotes.Services {

    public static class Utils {

        private static Random Counter = new Random();

        public static int NextCode () {
            return Counter.Next();
        }

        public static void MaybeExplode (this ValidationResult results) {
            if (!results.IsValid) {
                throw new ValidationException(results.Errors.First().ErrorMessage);
            }
        }
    }
}