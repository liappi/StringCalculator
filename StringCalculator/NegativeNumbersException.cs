using System;

namespace StringCalculator {
    public class NegativeNumbersException : Exception {
        public NegativeNumbersException(string message) : base(message) {

        }
    }
}