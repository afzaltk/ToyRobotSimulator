namespace ToyRobotSimulator
{
    public class TableTop
    {
        public int breadth;
        public int length;
        //Checks if the position of the robot is on the table surface
        public bool IsLocationValid(int lowerBound, int upperBound) => lowerBound >= 0 && lowerBound <= breadth && upperBound >= 0 && upperBound <= length;

        public TableTop(int breadth, int length)
        {
            this.breadth = breadth;
            this.length = length;
        }
    }
}