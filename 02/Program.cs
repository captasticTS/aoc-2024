using _02;

using (StreamReader reader = new StreamReader("../../../input.txt"))
{
    List<List<int>> reports = new();

    string? newLine = reader.ReadLine();

    while (newLine is not null)
    {
        List<string> numbersString = newLine.Split(" ").ToList();
        List<int> numbers = numbersString.Select(int.Parse).ToList();

        reports.Add(numbers);

        newLine = reader.ReadLine();
    }

    var result1 = reports.Count(x => XmasValidator.Verify(x, 0));
    var result2 = reports.Count(x => XmasValidator.VerifyAlternate(x));

    Console.WriteLine($"result for number 1: {result1}");
    Console.WriteLine($"result for number 2: {result2}");
}