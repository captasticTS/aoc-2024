var input = string.Empty;

using (StreamReader reader = new StreamReader("../../../input.txt"))
{
    input = reader.ReadToEnd();
}

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

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < columns; col++)
    {
        Console.Write(field[row, col]);
    }
    Console.WriteLine();
}
