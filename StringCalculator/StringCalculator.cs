using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string input) {
            var delimiters = new List<string>();
            delimiters.Add(",");
            delimiters.Add("\n");
            
            if (HasCustomDelimiter(input)) {
                var indexOfCustomDelimiter = input.IndexOf('\n');

                var customDelimiters = GetCustomDelimiters(input, indexOfCustomDelimiter);
                delimiters = delimiters.Concat(customDelimiters).ToList();
                
                input = GetNumbersFromInput(input, indexOfCustomDelimiter);
            }

            return AddNumbers(input, delimiters.ToArray());
        }

        private bool HasCustomDelimiter(string input) {
            var inputs = input.ToCharArray();
            return !input.Equals("") && inputs[0] == '/' && inputs[1] == '/' && input.Contains("\n");
        }

        private bool HasMultipleCustomDelimiters(string customDelimiter) {
            return customDelimiter.Contains("][");
        }

        private List<string> GetCustomDelimiters(string input, int indexOfCustomDelimiter) {
            var delimiters = new List<string>();
            
            var customDelimiter = input.Substring(2, indexOfCustomDelimiter - 2);
            
            if (customDelimiter.Length > 1) {
                customDelimiter = customDelimiter.Substring(1, customDelimiter.Length - 2);
                
                if (HasMultipleCustomDelimiters(customDelimiter)) {
                    delimiters = GetMultipleCustomDelimiters(customDelimiter);
                }
                else {
                    delimiters.Add(customDelimiter);
                }
            }
            else {
                delimiters.Add(customDelimiter);
            }

            return delimiters;
        }

        private List<string> GetMultipleCustomDelimiters(string customDelimiter) {
            var delimiters = new List<string>();
            
            var customDelimiters = customDelimiter.Split("][", StringSplitOptions.RemoveEmptyEntries);
            foreach (var delimiter in customDelimiters) {
                delimiters.Add(delimiter);
            }

            return delimiters;
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