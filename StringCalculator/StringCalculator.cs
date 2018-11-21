using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            string customDelimiter = null;
            var delimiters = new List<string>();
            delimiters.Add(",");
            delimiters.Add("\n");
            
            if (HasCustomDelimiter(input)) {
                var indexOfCustomDelimiter = input.IndexOf('\n');
                
                customDelimiter = GetCustomDelimiter(input, indexOfCustomDelimiter);

                if (customDelimiter.Contains("][")) {
                    var customDelimiters = customDelimiter.Split("][", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var delimiter in customDelimiters) {
                        delimiters.Add(delimiter);
                    }
                }
                else {
                    delimiters.Add(customDelimiter);
                }
                
                input = GetNumbersFromInput(input, indexOfCustomDelimiter);
                
            }

            return AddNumbers(input, delimiters.ToArray());
        }

        private bool HasCustomDelimiter(string input) {
            var inputs = input.ToCharArray();
            return !input.Equals("") && inputs[0] == '/' && inputs[1] == '/' && input.Contains("\n");
        }

        private string GetCustomDelimiter(string input, int indexOfCustomDelimiter) {
            var delimiter = input.Substring(2, indexOfCustomDelimiter - 2);
            if (delimiter.Length > 1) {
                delimiter = delimiter.Substring(1, delimiter.Length - 2);
            }

            return delimiter;
        }

        private string[] GetMultipleCustomDelimiters(string input, int indexOfCustomDelimiter) {
            var customDelimiters = input.Substring(2, indexOfCustomDelimiter - 2);
            if (customDelimiters.Length > 1) {
                customDelimiters = customDelimiters.Substring(1, customDelimiters.Length - 2);
            }

            return customDelimiters.Split("][", StringSplitOptions.RemoveEmptyEntries);
        }

        private string GetNumbersFromInput(string input, int indexOfCustomDelimiter) {
            return input.Substring(indexOfCustomDelimiter + 1);
        }

        private int AddNumbers(string input, string[] delimiters) {
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var negativeNumbers = new StringBuilder("");
        
            var sum = 0;
            foreach (var number in numbers) {
                if (int.Parse(number) < 0) {
                    negativeNumbers.Append(number);
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