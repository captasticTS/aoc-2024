using _05;

var rulesInput = string.Empty;
var pagesInput = string.Empty;


using (StreamReader reader = new StreamReader("../../../rules_input.txt"))
{
    rulesInput = reader.ReadToEnd();
}

using (StreamReader reader = new StreamReader("../../../pages_input.txt"))
{
    pagesInput = reader.ReadToEnd();
}

List<(int, int)> rules = new();
List<List<int>> pages = new();

foreach (var rule in rulesInput.Split("\n").Select(x => x.Trim()))
{
    var ruleNumbers = rule.Split("|").Select(x => int.Parse(x)).ToArray();

    rules.Add((ruleNumbers[0], ruleNumbers[1]));
}

foreach (var pagesNumbers in pagesInput.Split("\n").Select(x => x.Trim()))
{
    pages.Add(pagesNumbers.Split(",").Select(x => int.Parse(x)).ToList());
}

var sum1 = 0;
List<List<int>> wrongPages = new();

foreach (var pageCombination in pages)
{
    var orderedCorrectly = true;

    foreach (var rule in rules)
    {
        var firstIndex = pageCombination.IndexOf(rule.Item1);
        var secondIndex = pageCombination.IndexOf(rule.Item2);

        if (firstIndex != -1 && secondIndex != -1 && firstIndex > secondIndex)
        {
            orderedCorrectly = false;
            break;
        }
    }

    if (orderedCorrectly)
    {
        sum1 += pageCombination[pageCombination.Count / 2];
    }
    else
    {
        wrongPages.Add(pageCombination);
    }
}

var sum2 = 0;

foreach (var pageCombination in wrongPages)
{
    var correctedCombination = Ordering.Order(pageCombination, rules);

    sum2 += correctedCombination[correctedCombination.Count / 2];
}

Console.WriteLine($"solution for 1: {sum1}");
Console.WriteLine($"solution for 2: {sum2}");