using System;
using Xunit;
using Xunit.Abstractions;

namespace StringCalculator {
    public class UnitTest1 {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output) {
            this.output = output;
        }
        
        [Theory]
        [InlineData("", 0)]
        public void GivenAnEmptyStringReturnsZero(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("23", 23)]
        public void GivenANumberAsStringReturnsTheNumberAsInt(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("0,0", 0)]
        [InlineData("-1,2", 1)]
        [InlineData("-1\n2", 1)]
        public void GivenAStringOfTwoNumbersReturnsSum(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            output.WriteLine("Result: " + result);
            output.WriteLine("Expected: " + expected);
            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3,0,0", 6)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n4", 10)]
        [InlineData("1,2,3\n0,0", 6)]
        public void GivenAStringOfMultipleNumbersReturnsSum(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        [InlineData("//;\n1;2,3", 6)]
        [InlineData("//;\n1;2,3\n4", 10)]
        [InlineData("//;;\n1;;2;;3", 6)]
        public void GivenAStringOfMultipleNumbersSeparatedByCustomDelimiterReturnsSum(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            Assert.True(result.Equals(expected));
        }
    }
}