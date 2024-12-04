using System.Diagnostics.Tracing;

namespace _04;

public class Directions
{
    public static bool CheckForNextLetter(Direction direction, (int, int) currentPosition, char[,] field, string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return true;
        }

        try
        {
            int row = currentPosition.Item1;
            int col = currentPosition.Item2;

            if (field[row, col] != word[0])
            {
                return false;
            }

            var addStep = Vector[direction];
            var nextPosition = (row + addStep.Item1, col + addStep.Item2);

            return CheckForNextLetter(direction, nextPosition, field, word.Substring(1));
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }

    public enum Direction { Right, UpRight, Up, UpLeft, Left, DownLeft, Down, DownRight }

    public static Dictionary<Direction, (int, int)> Vector = new()
    {
        {Direction.Right, (1, 0) },
        {Direction.UpRight, (1, -1) },
        {Direction.Up, (0, -1) },
        {Direction.UpLeft, (-1, -1) },
        {Direction.Left, (-1, 0) },
        {Direction.DownLeft, (-1, 1) },
        {Direction.Down, (0, 1) },
        {Direction.DownRight, (1, 1) }
    };
}

