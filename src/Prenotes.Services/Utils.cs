
using System;

namespace Prenotes.Services {

    public static class Utils {

        private static Random Counter = new Random();

        public static int NextCode () {
            return Counter.Next();
        }
    }
}