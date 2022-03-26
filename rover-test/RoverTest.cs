using NUnit.Framework;
using System.Collections;

namespace MarsRover.Test
{

    public class RoverTest
    {

        [TestCase("L", ExpectedResult = "W")]
        [TestCase("LL", ExpectedResult = "S")]
        [TestCase("LLL", ExpectedResult = "E")]
        [TestCase("LLLL", ExpectedResult = "N")]
        [TestCase("R", ExpectedResult = "E")]
        [TestCase("RR", ExpectedResult = "S")]
        [TestCase("RRR", ExpectedResult = "W")]
        [TestCase("RRRR", ExpectedResult = "N")]
        [TestCase("LRLRLRLR", ExpectedResult = "N")]
        public string TestTurnLeftAndTurnRight_Rover(string instruction)
        {
            var rover = new Rover();
            rover.Position = new Coordinate { PointX = 0, PointY = 0, Direction = "N" };
            rover.Instructions = instruction;
            rover.StartNavigate();
            return rover.Position.Direction;
        }

        [TestCase("M", "N", ExpectedResult = "2 3")]
        [TestCase("MMM", "N", ExpectedResult = "2 5")]
        [TestCase("MMMMM", "N", ExpectedResult = "2 5")]
        [TestCase("M", "S", ExpectedResult = "2 1")]
        [TestCase("MM", "S", ExpectedResult = "2 0")]
        [TestCase("MMMMM", "S", ExpectedResult = "2 0")]
        [TestCase("M", "E", ExpectedResult = "3 2")]
        [TestCase("MM", "E", ExpectedResult = "4 2")]
        [TestCase("MMMMM", "E", ExpectedResult = "5 2")]
        [TestCase("M", "W", ExpectedResult = "1 2")]
        [TestCase("MM", "W", ExpectedResult = "0 2")]
        [TestCase("MMMMM", "W", ExpectedResult = "0 2")]
        public string TestMovingForward_Rover(string instruction, string direction)
        {
            var rover = new Rover();
            rover.Graph = new Coordinate { PointX = 5, PointY = 5 };
            rover.Position = new Coordinate { PointX = 2, PointY = 2, Direction = direction };
            rover.Instructions = instruction;
            rover.StartNavigate();
            return $"{rover.Position.PointX} {rover.Position.PointY}";
        }

        [Test]
        public void TestRover1()
        {
            var rover = new Rover();
            rover.Graph = new Coordinate { PointX = 5, PointY = 5 };
            rover.Position = new Coordinate { PointX = 1, PointY = 2, Direction = "N" };
            rover.Instructions = "LMLMLMLMM";
            rover.StartNavigate();

            Assert.AreEqual(rover.Position.PointX, 1);
            Assert.AreEqual(rover.Position.PointY, 3);
            Assert.AreEqual(rover.Position.Direction, "N");
        }

        [Test]
        public void TestRover2()
        {
            var rover = new Rover();
            rover.Graph = new Coordinate { PointX = 5, PointY = 5 };
            rover.Position = new Coordinate { PointX = 3, PointY = 3, Direction = "E" };
            rover.Instructions = "MMRMMRMRRM";
            rover.StartNavigate();

            Assert.AreEqual(rover.Position.PointX, 5);
            Assert.AreEqual(rover.Position.PointY, 1);
            Assert.AreEqual(rover.Position.Direction, "E");
        }
    }
}
