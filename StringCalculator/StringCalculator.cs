using System;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            if (input.Contains(",") || input.Contains("\n")) {
                return AddMultipleNumbers(input);
            }
            if (int.TryParse(input, out var output)) {
                return output;
            }
            return 0;
        }

        private int AddMultipleNumbers(string input) {
            char[] delimiters = {',', '\n'};
                
            var numbers = input.Split(delimiters);
            var sum = 0;
            foreach (var number in numbers) {
                sum += int.Parse(number);
            }

            return sum;
        }
    }
}