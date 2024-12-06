namespace _06_09;

public static class GuardMaze
{
    private record Collision()
    {
        public char Direction { get; init; }
        public int Row { get; init; }
        public int Col { get; init; }
    }
    
    public static readonly Dictionary<char, (int, int)> Directions = new()
    {
        { '^', (-1, 0) },
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) }
    };

    private static readonly Dictionary<char, char> NextCharacter = new()
    {
        { '^', '>' },
        { '>', 'v' },
        { 'v', '<' },
        { '<', '^' }
    };

    public static char[,] GetMaze(string input)
    {
        List<string> lines = input.Split("\n").Select(x => x.Trim()).ToList();
        
        var rows = lines.Count;
        var columns = lines[0].Length;

        char[,] field = new char[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                field[row, col] = lines[row][col];
            }
        }

        return field;
    }

    public static (int, int) LocateGuard(char[,] field)
    {
        var rows = field.GetLength(0);
        var columns = field.GetLength(1);
        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (NextCharacter.Keys.Contains(field[row, col]))
                {
                    return (row, col);
                }
            }
        }

        return (-1, -1);
    }
    
    public static char[,] SimulateGuard(char[,] input)
    {
        var field = (char[,])input.Clone();
        
        var rows = field.GetLength(0);
        var columns = field.GetLength(1);

        var guardPosition = LocateGuard(field);
        var row = guardPosition.Item1;
        var col = guardPosition.Item2;
        
        var hasExited = false;

        while (!hasExited)
        {
            try
            {
                var nextStep = Directions[field[row, col]];
                var facedCharacter = field[row + nextStep.Item1, col + nextStep.Item2];

                if (facedCharacter == '#')
                {
                    field[row, col] = NextCharacter[field[row, col]];
                }
                else
                {
                    field[row + nextStep.Item1, col + nextStep.Item2] = field[row, col];
                    field[row, col] = 'o';
                    row += nextStep.Item1;
                    col += nextStep.Item2;
                }
            }
            catch
            {
                hasExited = true;
                break;
            }
        }

        return field;
    }

    public static int CountSteppedOnFields(char[,] field)
    {
        var rows = field.GetLength(0);
        var columns = field.GetLength(1);
        var sum = 1;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                sum += field[row, col] == 'o' ? 1 : 0;
            }
        }

        return sum;
    }

    public static bool CheckForEndlessLoops(char[,] input)
    {
        var field = (char[,])input.Clone();
        
        var rows = field.GetLength(0);
        var columns = field.GetLength(1);
        
        var guardPosition = LocateGuard(field);
        var row = guardPosition.Item1;
        var col = guardPosition.Item2;
        
        List<Collision> collisions = new();
        
        var hasExited = false;

        while (!hasExited)
        {
            try
            {
                var nextStep = Directions[field[row, col]];
                var facedCharacter = field[row + nextStep.Item1, col + nextStep.Item2];

                if (facedCharacter == '#')
                {
                    var newCollision = new Collision()
                    {
                        Direction = field[row, col],
                        Row = row,
                        Col = col,
                    };

                    if (collisions.Contains(newCollision))
                    {
                        return true;
                    }
                    
                    collisions.Add(newCollision);
                    field[row, col] = NextCharacter[field[row, col]];
                }
                else
                {
                    field[row + nextStep.Item1, col + nextStep.Item2] = field[row, col];
                    field[row, col] = 'o';
                    row += nextStep.Item1;
                    col += nextStep.Item2;
                }
            }
            catch
            {
                hasExited = true;
                break;
            }
        }
        
        return false;
    }
}