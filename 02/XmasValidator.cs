namespace _02;

public class XmasValidator
{
    public static bool Verify(List<int> list, int tolerance = 0)
    {
        return (Math.Min(CountAscendingErrors(list), CountDescendingErrors(list)) + CountDistanceErrors(list)) <= tolerance;
    }

    public static bool VerifyAlternate(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var tempList = new List<int>(list);
            tempList.RemoveAt(i);
            if (Verify(tempList)) return true;
        }
        return false;
    }

    public static int CountAscendingErrors(List<int> list)
    {
        int errors = 0;
        if (list.Count == 0) return 0;

        int previousInt = list[0];

        foreach (int item in list)
        {
            if (item < previousInt) errors++;
            previousInt = item;
        }

        return errors;
    }

    public static int CountDescendingErrors(List<int> list)
    {
        int errors = 0;
        if (list.Count == 0) return 0;

        int previousInt = list[0];

        foreach (int item in list)
        {
            if (item > previousInt) errors++;
            previousInt = item;
        }

        return errors;
    }

    public static int CountDistanceErrors(List<int> list)
    {
        int errors = 0;
        if (list.Count == 0) return 0;

        int previousInt = list[0];

        for (int i = 1; i < list.Count; i++)
        {
            var item = list[i];
            var distance = Math.Abs(previousInt - item);
            if (0 == distance || distance > 3) errors++;
            previousInt = item;
        }

        return errors;
    }
}

