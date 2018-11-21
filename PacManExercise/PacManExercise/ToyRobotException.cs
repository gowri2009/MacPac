using System;

namespace PacManExercise
{
	public class ToyRobotException : Exception
	{

		private const long serialVersionUID = 8132983514127445438L;

		public ToyRobotException(string @string) : base(@string)
		{
		}

	}

}