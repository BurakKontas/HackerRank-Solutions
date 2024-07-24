var res = Result.nonDivisibleSubset(7, [278, 576, 496, 727, 410, 124, 338, 149, 209, 702, 282, 718, 771, 575, 436]);

var expected = 11; // 1, 7, 4

Console.WriteLine($"Actual value: {res}, Expected value: {expected}");
Console.WriteLine($"Is result expected: {res == expected}");

class Result
{

    /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        var remainderCounts = new int[k];

        foreach (var num in s)
        {
            remainderCounts[num % k]++;
        }

        var maxSubsetSize = 0;

        if (remainderCounts[0] > 0)
        {
            maxSubsetSize++;
        }

        for (var i = 1; i <= k / 2; i++)
        {
            if (i != k - i)
            {
                maxSubsetSize += Math.Max(remainderCounts[i], remainderCounts[k - i]);
            }
            else
            {
                maxSubsetSize++;
            }
        }

        return maxSubsetSize;
    }

}