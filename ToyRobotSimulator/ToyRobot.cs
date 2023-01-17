namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        public string? Direction { get; set; }
        public int East { get; set; }
        public int North { get; set; }
        public void Move()
        {
            switch (Direction)
            {
                case "east":
                    East += 1;
                    break;
                case "west":
                    East -= 1;
                    break;
                case "north":
                    North += 1;
                    break;
                case "south":
                    North -= 1;
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
            return East + "," + North + "," + Direction?.ToUpper();
        }
    }
}