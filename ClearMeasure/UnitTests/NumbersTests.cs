using System;
using System.Collections.Generic;
using NumbersClassLibrary;
using Xunit;

namespace UnitTests
{
    public class NumbersTests
    {
        private Dictionary<int, string> defaultRules = new Dictionary<int, string>() {{3, "fizz"}, {5, "buzz"}};
        [Fact]
        public void Test15()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 20, defaultRules);
            Assert.Equal("fizzbuzz", result[14]);
        }

        [Fact]
        public void LowerUpperBundary()
        {
            var nums = new Numbers();
            var ex = Assert.Throws<ArgumentException>(() => nums.PrintNumbers(10, 1, defaultRules));
            Assert.Equal("Upper less then Lower", ex.Message);
        }

        [Fact] 
        public void DoNotCreateLargeArrayIfNotNeededTest()
        {
            var nums = new Numbers();
            var hexMaxSize = 0X7FEFFFFF;
            var result = nums.PrintNumbers(hexMaxSize - 1000, hexMaxSize + 1000, defaultRules);
            Assert.NotEmpty(result);
        }

        //[Fact] 
        public void OutOfMemoryTest()
        {
            var nums = new Numbers();
            var hexMaxSize = 0X7FEFFFFF;
            var result = nums.PrintNumbers(1, hexMaxSize, defaultRules);
            Assert.NotEmpty(result);
        }


        [Fact]
        public void Test30()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 40, defaultRules);
            Assert.Equal("fizzbuzz", result[29]);
        }

        [Fact]
        public void Test3()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 4, defaultRules);
            Assert.Equal("fizz", result[2]);
        }

        [Fact]
        public void Test5()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 26, defaultRules);
            Assert.Equal("buzz", result[24]);
        }

        [Fact]
        public void Test7()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 7, defaultRules);
            Assert.Equal("7", result[6]);
        }

        [Fact]
        public void TestNewRules()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 30,  new Dictionary<int, string>() { { 4, "hello" }, { 7, "world" } });
            Assert.Equal("hello", result[7]);
            Assert.Equal("world", result[6]);
            Assert.Equal("helloworld", result[27]);
        }

        [Fact]
        public void OneRuleTest()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 30,  new Dictionary<int, string>() { { 4, "hello" } });
            Assert.Equal("hello", result[7]);
            Assert.Equal("9", result[8]);
        }

        [Fact]
        public void ThreeRuleTest()
        {
            var nums = new Numbers();
            var result = nums.PrintNumbers(1, 30,  new Dictionary<int, string>() { { 4, "hello4" }, { 5, "hello5" }, { 6, "hello6" } });
            Assert.Equal("hello6", result[5]);
            Assert.Equal("hello5", result[24]);
            Assert.Equal("hello4", result[27]);
            Assert.Equal("9", result[8]);
        }


    }
}
