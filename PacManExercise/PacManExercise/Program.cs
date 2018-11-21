using System;

namespace PacManExercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            PacManSquareBoard squareBoard = new PacManSquareBoard(4, 4);
            PacManRobot robot = new PacManRobot();
            PacManGame game = new PacManGame(squareBoard, robot);

            Console.WriteLine("PacMan Simulator");
            Console.WriteLine("Enter a command, Valid commands are:");
            Console.WriteLine("\'PLACE X,Y,NORTH|SOUTH|EAST|WEST\', MOVE, LEFT, RIGHT, REPORT or EXIT");

            bool keepRunning = true;
            while (keepRunning)
            {
                string inputString = Console.ReadLine();
                if ("EXIT".Equals(inputString))
                {
                    keepRunning = false;
                }
                else
                {
                    try
                    {
                        string outputVal = game.eval(inputString);
                        Console.WriteLine(outputVal);
                    }
                    catch (ToyRobotException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
