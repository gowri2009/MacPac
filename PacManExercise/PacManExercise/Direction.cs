using System.Collections.Generic;

namespace PacManExercise
{


	public sealed class Direction
	{

		public static readonly Direction NORTH = new Direction("NORTH", InnerEnum.NORTH, 0);
		public static readonly Direction EAST = new Direction("EAST", InnerEnum.EAST, 1);
		public static readonly Direction SOUTH = new Direction("SOUTH", InnerEnum.SOUTH, 2);
		public static readonly Direction WEST = new Direction("WEST", InnerEnum.WEST, 3);

		private static readonly IList<Direction> valueList = new List<Direction>();

		public enum InnerEnum
		{
			NORTH,
			EAST,
			SOUTH,
			WEST
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;
		private static IDictionary<int, Direction> map = new Dictionary<int, Direction>();

		static Direction()
		{

			valueList.Add(NORTH);
			valueList.Add(EAST);
			valueList.Add(SOUTH);
			valueList.Add(WEST);

            foreach (Direction directionEnum in Direction.values())
            {
                map.Add(directionEnum.directionIndex, directionEnum);
            }

        }

		private int directionIndex;

		private Direction(string name, InnerEnum innerEnum, int direction)
		{
			this.directionIndex = direction;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public static Direction valueOf(int directionNum)
		{
            return map[directionNum];

		}

		/// <summary>
		/// Returns the direction on the left of the current one
		/// </summary>
		public Direction leftDirection()
		{
			return rotate(-1);
		}

		/// <summary>
		/// Returns the direction on the right of the current one
		/// </summary>
		public Direction rightDirection()
		{
			return rotate(1);
		}

		private Direction rotate(int step)
		{

			int newIndex = (this.directionIndex + step) < 0 ? map.Count - 1 : (this.directionIndex + step) % map.Count;

			return Direction.valueOf(newIndex);
		}


		public static IList<Direction> values()
		{
			return valueList;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}
	}

}