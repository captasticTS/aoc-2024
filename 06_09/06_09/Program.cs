using System.Threading.Channels;
using _06_09;

var input = string.Empty;

using (StreamReader reader = new StreamReader("../../../../input.txt"))
{
    input = reader.ReadToEnd();
}

var field = GuardMaze.GetMaze(input);

var finishedField = GuardMaze.SimulateGuard(field);

var sum1 = GuardMaze.CountSteppedOnFields(finishedField);

var sum2 = 0;
var count = 0;

for (int row = 0; row < field.GetLength(0); row++)
{
    for (int col = 0; col < field.GetLength(1); col++)
    {
        if (GuardMaze.Directions.Keys.Contains(field[row, col]))
        {
            continue;
        }
        var tempField = (char[,])field.Clone();

        tempField[col, row] = '#';

        sum2 += GuardMaze.CheckForEndlessLoops(tempField) ? 1 : 0;
    }
}

Console.WriteLine($"answer for 1: {sum1}");
Console.WriteLine($"answer for 2: {sum2}");