using System;

namespace PacManExercise
{
	
	public class PacManGame
	{

		private PacManBoard squareBoard;
		private PacManRobot robot;

		public PacManGame(PacManBoard squareBoard, PacManRobot robot)
		{
			this.squareBoard = squareBoard;
			this.robot = robot;
		}

		/// <summary>
		/// Places the robot on the squareBoard  in position X,Y and facing NORTH, SOUTH, EAST or WEST
		/// </summary>
		/// <param name="position"> Robot position </param>
		/// <returns> true if placed successfully </returns>
		/// <exception cref="ToyRobotException"> </exception>

		public virtual bool placeToyRobot(Position position)
		{

			if (squareBoard == null)
			{
				throw new ToyRobotException("Invalid squareBoard object");
			}

			if (position == null)
			{
				throw new ToyRobotException("Invalid position object");
			}

			if (position.Direction == null)
			{
				throw new ToyRobotException("Invalid direction value");
			}

			// validate the position
			if (!squareBoard.isValidPosition(position))
			{
				return false;
			}

			// if position is valid then assign values to fields
			robot.Position = position;
			return true;
		}

		/// <summary>
		/// Evals and executes a string command.
		/// </summary>
		/// <param name="inputString"> command string </param>
		/// <returns> string value of the executed command </returns>
		/// <exception cref="com.gvnn.trb.exception.ToyRobotException">
		///  </exception>

		public virtual string eval(string inputString)
		{
			string[] args = inputString.Split(" ");

			// validate command
			Command command;
			try
			{
				command = (Command)Enum.Parse(typeof(Command), args[0]);
			}
			catch (System.ArgumentException)
			{
				throw new ToyRobotException("Invalid command");
			}
			if (command == Command.PLACE && args.Length < 2)
			{
				throw new ToyRobotException("Invalid command");
			}

			// validate PLACE params
			string[] @params;
			int x = 0;
			int y = 0;
			Direction commandDirection = null;
			if (command == Command.PLACE)
			{
				@params = args[1].Split(",");
				try
				{
					x = int.Parse(@params[0]);
					y = int.Parse(@params[1]);

					commandDirection = Direction.valueOf((int)Enum.Parse(typeof(Direction.InnerEnum), @params[2]));
				}
				catch (Exception)
				{
					throw new ToyRobotException("Invalid command");
				}
			}

			string output;

			switch (command)
			{
				case Command.PLACE:
					output = placeToyRobot(new Position(x, y, commandDirection)).ToString();
					break;
				case Command.MOVE:
					Position newPosition = robot.Position.NextPosition;
					if (!squareBoard.isValidPosition(newPosition))
					{
						output = false.ToString();
					}
					else
					{
						output = robot.move(newPosition).ToString();
					}
					break;
				case Command.LEFT:
					output = robot.rotateLeft().ToString();
					break;
				case Command.RIGHT:
					output = robot.rotateRight().ToString();
					break;
				case Command.REPORT:
					output = report();
					break;
				default:
					throw new ToyRobotException("Invalid command");
			}

			return output;
		}

		/// <summary>
		/// Returns the X,Y and Direction of the robot
		/// </summary>
		public virtual string report()
		{
			if (robot.Position == null)
			{
				return null;
			}

			return robot.Position.X + "," + robot.Position.Y + "," + robot.Position.Direction.ToString();
		}
	}

}