using System.Threading.Channels;
using _07;

var input = string.Empty;

using (StreamReader reader = new StreamReader("../../../../input.txt"))
{
    input = reader.ReadToEnd();
}

List<string> equationsInput = input.Split("\n").Select(x => x.Trim()).ToList();

long sum1 = 0;
long sum2 = 0;

foreach (var equation in equationsInput)
{
    var inputSplit = CombinationTester.GetNumbers(equation);
    
    sum1 += CombinationTester.TestCombination(inputSplit.Item1, inputSplit.Item2, false) ? 
        inputSplit.Item1 : 0;
    
    sum2 += CombinationTester.TestCombination(inputSplit.Item1, inputSplit.Item2, true) ? 
        inputSplit.Item1 : 0;
}

Console.WriteLine($"result of first exercise: {sum1}");
Console.WriteLine($"result of second exercise: {sum2}");