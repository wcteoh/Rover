using System;

namespace MarsRover
{
    /// <summary>
    /// 
    /// Rover navigation:
    /// 
    /// Plateua: Upper Right Corner => (5,5)
    ///          Lower Left Corner => (0, 0)
    ///    Size: 5 X 5
    /// Assume: Rover will not go out of this square.   
    /// 
    /// Input:Line 1: Rover's start position (Coordinate)
    ///       Line 2: Series of instruction (L=>Spin Left, R=>Spin Right, M=>Move Forward)
    /// Output: Rover's end position. (Coordinate)
    /// 
    /// 
    /// Test Data:
    /// Rover 1 Starting Position: 1 2 N
    /// Rover 1 Movement Plan: LMLMLMLMM
    /// Rover 1 Output: 1 3 N
    /// Rover 2 Starting Position: 3 3 E
    /// Rover 2 Movement Plan: MMRMMRMRRM
    /// Rover 2 Output: 5 1 E
    /// 
    /// </summary>

    internal class Program
    {
        private static readonly string[] rovers = { "Rover 1", "Rover 2" };

        static void Main(string[] args)
        {
            var roverNavigation = new Rover();
            var reader = new CommandLineReader();
            roverNavigation.Graph = reader.ReadCoordinate("Enter Graph Upper Right Coordinate: ");

            foreach(var rover in rovers)
            {
                roverNavigation.Position = reader.ReadCoordinate($"{rover} Starting Position: ", true);
                roverNavigation.Instructions = reader.ReadInstruction($"{rover} Movement Plan: ");
                roverNavigation.StartNavigate();
                Console.WriteLine($"{rover} Output: {roverNavigation.Position.PointX} {roverNavigation.Position.PointY} {roverNavigation.Position.Direction}");
            }
            Console.ReadLine();
        }
    }
}


