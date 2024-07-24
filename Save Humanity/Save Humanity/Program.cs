Result.virusIndices("abbab", "ba"); // should print 1 2
Result.virusIndices("hello", "World"); // should print No Match!
Result.virusIndices("banana", "nan"); // should print 0 2

class Result
{

    /*
     * Complete the 'virusIndices' function below.
     *
     * The function accepts following parameters:
     *  1. STRING p
     *  2. STRING v
     */ 

    public static void virusIndices(string p, string v)
    {
        var pLength = p.Length;
        var vLength = v.Length;

        var result = new List<int>();

        var combined1 = v + " " + p;
        var combined2 = new string(v.Reverse().ToArray()) + " " + new string(p.Reverse().ToArray());


        var forwardLengths = ComputePalindromicLengths(combined1);
        var reverseLengths = ComputePalindromicLengths(combined2);

        for (var i = 0; i <= pLength - vLength; i++)
        {
                                                                                                            //  bu + 1 kaç fire verilebileceğini belirtiyor
            if (forwardLengths[vLength + 1 + i] == vLength || forwardLengths[vLength + i + 1] + reverseLengths[pLength + 1 - i] + 1 >= vLength)
                result.Add(i);
        }

        if (result.Count > 0)
            Console.WriteLine(string.Join(" ", result));
        else
            Console.WriteLine("No Match!");
    }

    private static int[] ComputePalindromicLengths(string text)
    {
        var length = text.Length;
        var leftBoundary = 0;
        var rightBoundary = 0;
        var palindromicLengths = new int[length];
        for (var i = 1; i < length; i++)
        {
            if (palindromicLengths[i - leftBoundary] < rightBoundary - i + 1)
                palindromicLengths[i] = palindromicLengths[i - leftBoundary];
            else
            {
                leftBoundary = i;
                rightBoundary = Math.Max(i, rightBoundary);
                while (rightBoundary < length && text[rightBoundary - leftBoundary] == text[rightBoundary])
                    rightBoundary++;
                palindromicLengths[i] = rightBoundary - leftBoundary;
                rightBoundary--;
            }
        }
        return palindromicLengths;
    }
}