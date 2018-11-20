using System;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            if (int.TryParse(input, out var output)) {
                return output;
            }
            return 0;
        }
    }
}