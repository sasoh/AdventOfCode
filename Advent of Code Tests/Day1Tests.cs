using Advent_of_Code;

namespace Advent_of_Code_Tests
{
    public class Day1Tests
    {
        [TestCase("1a2", 12)]
        [TestCase("treb7uchet", 77)]
        [TestCase("a1b2c3d4e5f", 15)]
        public void Day1Solve1_GivenSingleLineString_ShouldReturnExpectedNumber(string input, int expected)
        {
            var sut = new Day1Solver();
            
            var result = sut.Solve1(input);

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Day1Solve1s_GivenMultiLineString_ShouldReturnExpectedNumber()
        {
            const string input = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
            const int expected = 142;
            
            var sut = new Day1Solver();
            
            var result = sut.Solve1(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}