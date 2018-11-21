using System;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            if (HasCustomDelimiter(input)) {
                var indexOfDelimiter = input.IndexOf('\n');
                var delimiter = input.Substring(2, indexOfDelimiter - 2);
                var numbersFromInput = input.Substring(indexOfDelimiter + 1);

                return AddMultipleNumbers(numbersFromInput, delimiter);
            }

            return AddMultipleNumbers(input, null);
        }

        private bool HasCustomDelimiter(string input) {
            var inputs = input.ToCharArray();
            return !input.Equals("") && inputs[0] == '/' && inputs[1] == '/' && input.Contains("\n");
        }

        private int AddMultipleNumbers(string input, string customDelimiter) {
            var delimiters = new [] {",", "\n", customDelimiter};
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        
            var sum = 0;
            foreach (var number in numbers) {
                if (int.Parse(number) < 0) {
                    throw new NegativeNumbersException("Negatives not allowed");
                }

                if (int.Parse(number) >= 1000) {
                    continue;
                }
                sum += int.Parse(number);
            }

            return sum;
        }
    }
}