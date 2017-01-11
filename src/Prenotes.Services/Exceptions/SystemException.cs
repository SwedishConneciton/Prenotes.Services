
using System;

namespace Prenotes.Services.Exceptions {

    public class SystemException : Exception {

        public SystemException(string message) : base(message) {
            
        } 
    }
}