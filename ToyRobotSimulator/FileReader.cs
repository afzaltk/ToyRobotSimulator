using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ToyRobotSimulator
{
    public class FileReader
    {

        readonly static TableTop TableTop = new(6, 6);
        public static Simulation? Simulator;
        public static string Message = string.Empty;
        public static bool IsPlaced = false;

        public static void ReadFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, filename));

                if (lines.Length == 0)
                {
                    Console.WriteLine("No commands found in the text file");
                    return;
                }

                Simulator = new Simulation(TableTop);

                foreach (string line in lines)
                {
                    if (IsPlaced)
                        ProcessLine(line);
                    else if (line.Contains("PLACE"))
                    {
                        ProcessLine(line);
                    }                   
                    if (Message.Length > 1)
                    {
                        Console.WriteLine(Message);
                        Message = String.Empty;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void ProcessLine(string line)
        {

            if (line.Contains("PLACE"))
            {
                string[] position = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                bool eastCheck = Int32.TryParse(position[1], out int east);
                bool northCheck = Int32.TryParse(position[2], out int north);

                if (eastCheck && northCheck && TableTop.IsLocationValid(east,north))
                {
                    if (position.Length == 4)
                    {
                        Simulator.Place(east, north, position[3]);
                        IsPlaced = true;
                    }                        
                    else if(IsPlaced)
                        Simulator.Place(east, north,Simulator.Robot.Direction);
                }

            }
            else if (line.Contains("MOVE") || line.Contains("RIGHT") || line.Contains("LEFT"))
            {
                Simulator?.RobotMoves(line.ToLower());
            }
            else if (line.Contains("REPORT"))
            {
                Message = Simulator.ShowReport();
            }
           
        }
    }
}
