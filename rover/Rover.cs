
namespace MarsRover
{
    public class Rover
    {
        private static readonly string Directions = "NESW";
        public Coordinate Graph { get; set; }
        public Coordinate Position { get; set; }
        public string Instructions { get; set; }
        public Rover()
        {
        }

        public void StartNavigate()
        {
            foreach (var action in Instructions)
            {
                if (string.Compare(action.ToString(), "M", true) == 0)
                {
                    moveForward();
                }
                else if (string.Compare(action.ToString(), "L", true) == 0)
                {
                    turnLeft();
                }
                else if (string.Compare(action.ToString(), "R", true) == 0)
                {
                    turnRight();
                }
            }
        }

        private void moveForward()
        {
            switch (Position.Direction)
            {
                case "N":
                    Position.PointY = Position.PointY < Graph.PointY ? Position.PointY + 1 : Graph.PointY;
                    break;
                case "S":
                    Position.PointY = Position.PointY > 0 ? Position.PointY - 1 : 0;
                    break;
                case "E":
                    Position.PointX = Position.PointX < Graph.PointX ? Position.PointX + 1 : Graph.PointX;
                    break;
                case "W":
                    Position.PointX = Position.PointX > 0 ? Position.PointX - 1 : 0;
                    break;
            }
        }

        private void turnLeft()
        {
            var currentIndex = Directions.IndexOf(Position.Direction);
            var newIndex = currentIndex - 1;
            if (newIndex < 0)
            {
                newIndex = newIndex + 4;
            }
            Position.Direction = Directions[newIndex % 4].ToString();
        }

        private void turnRight()
        {
            var currentIndex = Directions.IndexOf(Position.Direction);
            var newIndex = currentIndex + 1;
            Position.Direction = Directions[newIndex % 4].ToString();
        }

    }
}
