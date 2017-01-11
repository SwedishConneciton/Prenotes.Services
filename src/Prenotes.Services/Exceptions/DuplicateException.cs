
using System;

namespace Prenotes.Services.Exceptions {

    public class DuplicateException : Exception {

        public DuplicateException(string message) : base(message) {
            
        } 
    }
}