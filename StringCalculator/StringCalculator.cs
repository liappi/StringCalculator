using System;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            if (hasCustomDelimiter(input)) {
                var indexOfDelimiter = input.IndexOf('\n');
                var delimiter = input.Substring(2, indexOfDelimiter - 2);
                var numbersFromInput = input.Substring(indexOfDelimiter + 1);

                return AddMultipleNumbers(numbersFromInput, delimiter);
            }
            
            if (input.Contains(",") || input.Contains("\n")) {
                return AddMultipleNumbers(input, null);
            }
            
            if (int.TryParse(input, out var output)) {
                return output;
            }
            
            return 0;
        }

        private bool hasCustomDelimiter(string input) {
            char[] inputAsChars = input.ToCharArray();
            return !input.Equals("") && inputAsChars[0] == '/' && inputAsChars[1] == '/' && input.Contains("\n");
        }

        private int AddMultipleNumbers(string input, string customDelimiter) {
            string[] delimiters = {",", "\n", customDelimiter};
            string[] numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        
            var sum = 0;
            foreach (var number in numbers) {
                sum += int.Parse(number);
            }

            return sum;
        }
    }
}