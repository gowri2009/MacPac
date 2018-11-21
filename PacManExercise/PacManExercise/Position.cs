namespace PacManExercise
{

	public class Position
	{
		internal int x;
		internal int y;
		internal Direction direction;

		public Position(Position position)
		{
			this.x = position.X;
			this.y = position.Y;
			this.direction = position.Direction;
		}

		public Position(int x, int y, Direction direction)
		{
			this.x = x;
			this.y = y;
			this.direction = direction;
		}

		public virtual int X
		{
			get
			{
				return this.x;
			}
		}

		public virtual int Y
		{
			get
			{
				return this.y;
			}
		}

		public virtual Direction Direction
		{
			get
			{
				return this.direction;
			}
			set
			{
				this.direction = value;
			}
		}


		public virtual void change(int x, int y)
		{
			this.x = this.x + x;
			this.y = this.y + y;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public Position getNextPosition() throws com.gvnn.trb.exception.ToyRobotException
		public virtual Position NextPosition
		{
			get
			{
				if (this.direction == null)
				{
					throw new ToyRobotException("Invalid robot direction");
				}
    
				// new position to validate
				Position newPosition = new Position(this);
				switch (this.direction.innerEnumValue)
				{
					case Direction.InnerEnum.NORTH:
						newPosition.change(0, 1);
						break;
					case Direction.InnerEnum.EAST:
						newPosition.change(1, 0);
						break;
					case Direction.InnerEnum.SOUTH:
						newPosition.change(0, -1);
						break;
					case Direction.InnerEnum.WEST:
						newPosition.change(-1, 0);
						break;
				}
				return newPosition;
			}
		}
	}

}