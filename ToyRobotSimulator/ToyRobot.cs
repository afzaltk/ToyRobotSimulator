namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        public string? Direction { get; set; }
        public int EastPosition { get; set; }
        public int NorthPosition { get; set; }
        public void Move()
        {
            switch (Direction)
            {
                case "east":
                    EastPosition += 1;
                    break;
                case "west":
                    EastPosition -= 1;
                    break;
                case "north":
                    NorthPosition += 1;
                    break;
                case "south":
                    NorthPosition -= 1;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case "east":
                    Direction = "north";
                    break;
                case "west":
                    Direction = "south";
                    break;
                case "north":
                    Direction = "west";
                    break;
                case "south":
                    Direction = "east";
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case "east":
                    Direction = "south";
                    break;
                case "west":
                    Direction = "north";
                    break;
                case "north":
                    Direction = "east";
                    break;
                case "south":
                    Direction = "west";
                    break;
            }
        }

        public string ShowReport()
        {
            return EastPosition + "," + NorthPosition + "," + Direction?.ToUpper();
        }
    }
}