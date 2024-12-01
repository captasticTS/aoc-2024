using System.Threading.Channels;

List<int> leftList = new();
List<int> rightList = new();

using (StreamReader reader = new StreamReader("../../../../input.txt"))
{
    string? currentLine = reader.ReadLine();

    while (currentLine is not null)
    {
        var numbers = currentLine.Split("   ");

        try
        {
            leftList.Add(int.Parse(numbers[0]));
            rightList.Add(int.Parse(numbers[1]));
        }
        catch
        {
            Console.WriteLine($"error for {numbers[0]} and {numbers[1]}");
        }
        
        currentLine = reader.ReadLine();
    }
}

leftList = leftList.Order().ToList();
rightList = rightList.Order().ToList();

int sum1 = 0;
int sum2 = 0;

for (int i = 0; i < leftList.Count; i++)
{
    sum1 += Math.Abs(leftList[i] - rightList[i]);
    sum2 += leftList[i] * rightList.Count(x => x == leftList[i]);
}

Console.WriteLine($"Answer to part 1: {sum1}");
Console.WriteLine($"Answer to part 2: {sum2}");

