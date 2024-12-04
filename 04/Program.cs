using _04;
using static _04.Directions;

var input = string.Empty;

using (StreamReader reader = new StreamReader("../../../input.txt"))
{
    input = reader.ReadToEnd();
}

var lines = input.Split('\n').Select(x => x.Trim()).ToArray();


var yLength = lines.Length;
var xLength = lines[0].Length;

char[,] field = new char[yLength, xLength];

for (int row = 0; row < yLength; row++)
{
    for (int col = 0; col < xLength; col++)
    {
        field[row, col] = lines[row][col];
    }
}

int sum1 = 0;
int sum2 = 0;

for (int row = 0; row < yLength; row++)
{
    for (int col = 0; col < xLength; col++)
    {
        foreach (var direction in Directions.Vector.Keys)
        {
            if (Directions.CheckForNextLetter(direction, (col, row), field, "XMAS"))
            {
                sum1++;
            }
        }

        var DownRightMas = Directions.CheckForNextLetter(Direction.DownRight, (col, row), field, "MAS");
        var DownLeftMas = Directions.CheckForNextLetter(Direction.DownLeft, (col + 2, row), field, "MAS");
        var DownRightSam = Directions.CheckForNextLetter(Direction.DownRight, (col, row), field, "SAM");
        var DownLeftSam = Directions.CheckForNextLetter(Direction.DownLeft, (col + 2, row), field, "SAM");

        if ((DownRightMas || DownRightSam) && (DownLeftMas || DownLeftSam))
        {
            sum2++;
        }

}
}

Console.WriteLine($"solution for 1: {sum1}");
Console.WriteLine($"solution for 2: {sum2}");

