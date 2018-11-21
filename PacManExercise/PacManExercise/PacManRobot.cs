namespace PacManExercise
{
	
	public class PacManRobot
	{

		private Position position;

		public PacManRobot()
		{
		}

		public PacManRobot(Position position)
		{
			this.position = position;
		}

		public virtual bool setPosition(Position position)
		{
			if (position == null)
			{
				return false;
			}

			this.position = position;
			return true;
		}


		public virtual bool move()
		{
			return move(position.NextPosition);
		}

		/// <summary>
		/// Moves the robot one unit forward in the direction it is currently facing
		/// </summary>
		/// <returns> true if moved successfully </returns>
		public virtual bool move(Position newPosition)
		{
			if (newPosition == null)
			{
				return false;
			}

			// change position
			this.position = newPosition;
			return true;
		}

		public virtual Position Position
		{
			get
			{
				return this.position;
			}
            set
            {
                this.position = value;
            }
		}

		/// <summary>
		/// Rotates the robot 90 degrees LEFT
		/// </summary>
		/// <returns> true if rotated successfully </returns>
		public virtual bool rotateLeft()
		{
			if (this.position.Direction == null)
			{
				return false;
			}

			this.position.Direction = this.position.Direction.leftDirection();
			return true;
		}

		/// <summary>
		/// Rotates the robot 90 degrees RIGHT
		/// </summary>
		/// <returns> true if rotated successfully </returns>
		public virtual bool rotateRight()
		{
			if (this.position.Direction == null)
			{
				return false;
			}

			this.position.Direction = this.position.Direction.rightDirection();
			return true;
		}

	}

}