using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _05;

internal class Ordering
{
    public static List<int> Order (List<int> pageCombination, List<(int, int)> rules)
    {
        var alreadyOrdered = true;

        foreach (var rule in rules)
        {
            var firstIndex = pageCombination.IndexOf(rule.Item1);
            var secondIndex = pageCombination.IndexOf(rule.Item2);

            if (firstIndex != -1 && secondIndex != -1 && firstIndex > secondIndex)
            {
                alreadyOrdered = false;
                var temp = pageCombination[firstIndex];
                pageCombination[firstIndex] = pageCombination[secondIndex];
                pageCombination[secondIndex] = temp;
            }
        }

        if (alreadyOrdered)
        {
            return pageCombination;
        }
        else
        {
            return Order(pageCombination, rules);
        }
    }
}

