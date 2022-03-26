using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover
{

    public class CommandLineReader
    {
        private static readonly Regex coordinatePattern = new Regex(@"^\d+\s\d+(\s[NSWE])?$");
        private static readonly Regex instructionPattern = new Regex(@"^[LRM]+$");

        public string ReadInstruction(string entryTitle)
        {
            do
            {
                Console.Write(entryTitle);
                string readLine = Console.ReadLine().Trim();
                if (instructionPattern.Match(readLine).Success)
                {
                    return readLine;
                }
                Console.WriteLine("Invalid entry. Please try again.");
            } while (true);
        }

        public Coordinate ReadCoordinate(string entryTitle, bool requireDirection = false)
        {
            do
            {
                Console.Write(entryTitle);
                string readLine = Console.ReadLine().Trim();
                Coordinate result = null;
                if (coordinatePattern.Match(readLine).Success)
                {
                    string[] splitLine = Regex.Split(readLine, @"\s{1,}");
                    result = validateCoordinate(splitLine[0], splitLine[1]);

                    if (requireDirection)
                    {
                        if (splitLine.Length > 2 && !string.IsNullOrEmpty(splitLine[2]))
                        {
                            result.Direction = splitLine[2];
                        }
                        else
                        {
                            result = null;
                        }
                    }
                }

                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            } while (true);
        }

        private Coordinate validateCoordinate(string X, string Y)
        {
            int ptX, ptY;
            if (Int32.TryParse(X, out ptX) &&
                Int32.TryParse(Y, out ptY))
            {
                return new Coordinate { PointX = ptX, PointY = ptY };
            }
            return null;
        }

    }

}
