using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Test
{
    public class CommandLineReaderTest
    {

        [Test]
        public void TestValidCoordnateForGraph_CommandLineReader()
        {
            Console.SetIn(new StringReader("2 3"));
            CommandLineReader reader = new CommandLineReader();
            var result = reader.ReadCoordinate("");

            Assert.AreEqual(result.PointX, 2);
            Assert.AreEqual(result.PointY, 3);
            Assert.AreEqual(result.Direction, null);
        }

        [Test]
        public void TestValidInstruction_CommandLineReader()
        {
            Console.SetIn(new StringReader("LMLMLMLMM"));
            CommandLineReader reader = new CommandLineReader();
            var result = reader.ReadInstruction("");

            Assert.AreEqual(result, "LMLMLMLMM");
            Assert.That(result.Length, Is.EqualTo(9));
        }


    }
}
