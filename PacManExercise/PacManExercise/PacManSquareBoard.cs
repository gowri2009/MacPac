namespace PacManExercise
{
	public class PacManSquareBoard : PacManBoard
	{

		internal int rows;
		internal int columns;

		public PacManSquareBoard(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;
		}

		public virtual bool isValidPosition(Position position)
		{
			return !(position.X > this.columns || position.X < 0 || position.Y > this.rows || position.Y < 0);
		}
	}

}