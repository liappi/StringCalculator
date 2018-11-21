using System;
using System.Text;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            string customDelimiter = null;
            
            if (HasCustomDelimiter(input)) {
                var indexOfCustomDelimiter = input.IndexOf('\n');
                
                customDelimiter = GetDelimiter(input, indexOfCustomDelimiter);
                input = GetNumbersFromInput(input, indexOfCustomDelimiter);
            }

            return AddNumbers(input, customDelimiter);
        }

        private bool HasCustomDelimiter(string input) {
            var inputs = input.ToCharArray();
            return !input.Equals("") && inputs[0] == '/' && inputs[1] == '/' && input.Contains("\n");
        }

        private string GetDelimiter(string input, int indexOfCustomDelimiter) {
            return input.Substring(2, indexOfCustomDelimiter - 2);
        }

        private string GetNumbersFromInput(string input, int indexOfCustomDelimiter) {
            return input.Substring(indexOfCustomDelimiter + 1);
        }

        private int AddNumbers(string input, string customDelimiter) {
            var delimiters = new [] {",", "\n", customDelimiter};
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var negativeNumbers = new StringBuilder("");
        
            var sum = 0;
            foreach (var number in numbers) {
                if (int.Parse(number) < 0) {
                    negativeNumbers.Append(int.Parse(number));
                }

                if (int.Parse(number) >= 1000) {
                    continue;
                }
                sum += int.Parse(number);
            }

            if (negativeNumbers.Length > 0) {
                throw new Exception("Negatives not allowed" + negativeNumbers);
            }

            return sum;
        }
    }
}