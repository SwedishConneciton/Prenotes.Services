
using System;

namespace Prenotes.Services.Exceptions {

    public class DuplicateException : Exception {

        private readonly string key;

        private readonly object value;

        public DuplicateException(string key, object value) : base($"Id {key} not unique with value {value}") {
            this.key = key;
            this.value = value;
        } 
    }
}