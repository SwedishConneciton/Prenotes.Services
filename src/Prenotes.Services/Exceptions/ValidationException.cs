
using System;

namespace Prenotes.Services.Exceptions {

    public class ValidationException : Exception {

        public ValidationException(string message) : base(message) {
            
        } 
    }
}