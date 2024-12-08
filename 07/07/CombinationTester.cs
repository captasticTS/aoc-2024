namespace _07;

public static class CombinationTester
{
    public static (long, List<long>) GetNumbers(string input)
    {
        var inputSplit = input.Split(":").Select(x => x.Trim()).ToList();
        
        var result = long.Parse(inputSplit[0]);
        
        var combinators = inputSplit[1].Split(" ").Select(x => long.Parse(x)).ToList();
        
        return (result, combinators);
    }

    public static bool TestCombination(long result, List<long> combinators, bool allowConcatination)
    {
        if (combinators.Count == 2)
        {
            return combinators[0] + combinators[1] == result || 
                   combinators[0] * combinators[1] == result ||
                   allowConcatination && long.Parse(combinators[0].ToString() + combinators[1].ToString()) == result;
        }
        
        var worksWithPlus = TestCombination(result, new List<long> {combinators[0] + combinators[1]}
            .Concat(combinators.Skip(2)).ToList(), allowConcatination);
        
        var worksWithTimes = TestCombination(result, new List<long> {combinators[0] * combinators[1]}
            .Concat(combinators.Skip(2)).ToList(), allowConcatination);
        
        var worksWithConcatination = allowConcatination && TestCombination(result, new List<long> 
                {long.Parse(combinators[0].ToString() + combinators[1].ToString())}
                .Concat(combinators.Skip(2)).ToList(), allowConcatination);
        
        return worksWithPlus || worksWithTimes || worksWithConcatination;
    }

    public static bool TestCombination(string input, bool allowConcatination)
    {
        var inputSplit = GetNumbers(input);
        
        return TestCombination(inputSplit.Item1, inputSplit.Item2, allowConcatination);
    }
}