using ToyRobotSimulator;

namespace ToyRobotTest
{
    public class SimulationTests
    {
        [Theory]
        [InlineData(1, "east")]
        [InlineData(3, "east")]
        [InlineData(1, "west")]
        [InlineData(3, "west")]
        [InlineData(1, "north")]
        [InlineData(3, "north")]
        [InlineData(1, "south")]
        [InlineData(3, "south")]
        [InlineData(0, "south")]
        [InlineData(0, "east")]
        [InlineData(0, "west")]
        [InlineData(0, "north")]
        //Tests if the movements are correctly made on the right direction and the right amount
        public void MovementsToAllDirections(int times, string direction)
        {
            int movements = 0;
            int movedDirectionLength = 0;
            ToyRobot Robot = new() { Direction = direction };

            while (movements != times)
            {
                Robot.Move();
                movements++;
            }
            switch (direction)
            {
                case "east":
                    movedDirectionLength = Robot.EastPosition;
                    break;
                case "west":
                    movedDirectionLength = Robot.EastPosition;
                    times = -times;
                    break;
                case "north":
                    movedDirectionLength = Robot.NorthPosition;
                    break;
                case "south":
                    movedDirectionLength = Robot.NorthPosition;
                    times = -times;
                    break;
            }

            Assert.Equal(times, movedDirectionLength);
        }

        [Theory]
        [InlineData("north", "LEFT", "west")]
        [InlineData("north", "RIGHT", "east")]
        [InlineData("east", "LEFT", "north")]
        [InlineData("east", "RIGHT", "south")]
        [InlineData("south", "LEFT", "east")]
        [InlineData("south", "RIGHT", "west")]
        [InlineData("west", "LEFT", "south")]
        [InlineData("west", "RIGHT", "north")]
        //Tests if the robot turns to the correct direction from a given current direction based on the turn it does
        public void TurningInAlldirections(string facingDirection, string turnToDirection, string expectedDirection)
        {
            ToyRobot Robot = new() { Direction = facingDirection.ToLower() };
            switch (turnToDirection)
            {
                case "LEFT":
                    Robot.TurnLeft();
                    break;
                case "RIGHT":
                    Robot.TurnRight();
                    break;
            }

            Assert.Equal(expectedDirection, Robot.Direction);
        }

        [Theory]
        [InlineData(4, 4, 6, 6, true)]
        [InlineData(7, 7, 6, 6, false)]
        [InlineData(0, 0, 6, 6, true)]
        [InlineData(-1, 0, 6, 6, false)]
        [InlineData(3, 7, 6, 6, false)]
        [InlineData(6, 6, 6, 6, true)]
        //checks if the location where the robot has to be placed is on the table surface
        public void ValidLocationsToPlaceRobotOnATabletTop(int positionX, int positionY, int tableWidth, int tableLength, bool expectedOutput)
        {
            TableTop table = new(tableWidth, tableLength);
            Assert.Equal(table.IsLocationValid(positionX, positionY), expectedOutput);
        }


    }
}