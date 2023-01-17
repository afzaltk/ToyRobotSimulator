namespace ToyRobotSimulator
{
    public class Simulation
    {
        public TableTop? CurrentSurface; 
        public ToyRobot? Robot;

        public Simulation(TableTop tableTop)
        {
            CurrentSurface = tableTop;
        }

        public void Place(int east, int north, string direction)
        {
            if (CurrentSurface.IsLocationValid(east, north))
            {
                Robot = new ToyRobot
                {
                    Direction = direction.ToLower(),
                    EastPosition = east,
                    NorthPosition = north
                };
            }
        }

        public void RobotMoves(string movement)
        {
            switch (movement)
            {
                case "move":
                    if (CurrentSurface.IsLocationValid(Robot.EastPosition + 1, Robot.NorthPosition + 1))
                    {
                        Robot.Move();
                    }
                    break;
                case "right":
                    Robot.TurnRight();
                    break;
                case "left":
                    Robot.TurnLeft();
                    break;
            }
        }

        public string ShowReport()
        {
            return Robot.ShowReport();
        }
    }
}