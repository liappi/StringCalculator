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
        [InlineData("something", 0)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("23", 23)]
        public void GivenAStringReturnsANumber(string input, int expected) {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(input);
            
            Assert.True(result.Equals(expected));
        }
    }
}