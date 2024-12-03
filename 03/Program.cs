using System.Text.RegularExpressions;

var input = string.Empty;

using (StreamReader reader = new StreamReader("../../../input.txt"))
{
    input = reader.ReadToEnd();
}

int sum1 = 0;
int sum2 = 0;

string mulPattern = @"mul\((\d+),(\d+)\)";
Regex mulRegex = new Regex(mulPattern);

var input2 = input.Substring(0);
List<string> activatedStrings = new();
var isActive = true;

while (input2 != "")
{
    if (isActive)
    {
        var nextDeactivation = input2.IndexOf("don't()");
        
        if (nextDeactivation == -1)
        {
            activatedStrings.Add(input2.Substring(0));
            break;
        }

        activatedStrings.Add(input2.Substring(0, nextDeactivation));
        input2 = input2.Substring(nextDeactivation);
        isActive = false;
    }
    else
    {
        var nextActivation = input2.IndexOf("do()");

        if (nextActivation == -1)
        {
            break;
        }

        input2 = input2.Substring(nextActivation);
        isActive = true;
    }
}

foreach (Match match in mulRegex.Matches(input))
{
    if (match.Groups.Count == 3)
    {
        var firstValue = int.Parse(match.Groups[1].Value);
        var secondValue = int.Parse(match.Groups[2].Value);

        sum1 += firstValue * secondValue;
    }
}

foreach (var tempInput in activatedStrings)
{
    foreach (Match match in mulRegex.Matches(tempInput))
    {
        if (match.Groups.Count == 3)
        {
            var firstValue = int.Parse(match.Groups[1].Value);
            var secondValue = int.Parse(match.Groups[2].Value);

            sum2 += firstValue * secondValue;
        }
    }
}

Console.WriteLine($"result for 1: {sum1}");
Console.WriteLine($"result for 2: {sum2}");