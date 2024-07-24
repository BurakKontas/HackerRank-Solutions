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

class RabinKarp
{
    static int prime = 101;

    public static List<int> Search(string text, string pattern)
    {
        var m = pattern.Length;
        var n = text.Length;
        var patternHash = CreateHash(pattern, m - 1);
        var textHash = CreateHash(text, m - 1);
        var result = new List<int>();

        for (var i = 0; i <= n - m; i++)
        {
            if (IsOneMismatch(pattern, text, i))
            {
                result.Add(i);
            }
            if (i < n - m)
            {
                textHash = RecalculateHash(text, i, i + m, textHash, m);
            }
        }
        return result;
    }

    static long CreateHash(string str, int end)
    {
        long hash = 0;
        for (var i = 0; i <= end; i++)
        {
            hash += str[i] * (long)Math.Pow(prime, i);
        }
        return hash;
    }

    static long RecalculateHash(string str, int oldIndex, int newIndex, long oldHash, int patternLen)
    {
        var newHash = oldHash - str[oldIndex];
        newHash /= prime;
        newHash += str[newIndex] * (long)Math.Pow(prime, patternLen - 1);
        return newHash;
    }

    // checks with 1 mismatch (line 82)
    static bool IsOneMismatch(string pattern, string text, int startIndex)
    {
        var mismatchCount = 0;
        for (var j = 0; j < pattern.Length; j++)
        {
            if (text[startIndex + j] == pattern[j]) continue;
            
            mismatchCount++;
            
            if (mismatchCount > 1)
            {
                return false;
            }
        }
        return true;
    }

    // checks full pattern match
    static bool CheckEqual(string str1, int start1, int end1, string str2, int start2, int end2)
    {
        if (end1 - start1 != end2 - start2)
        {
            return false;
        }
        while (start1 <= end1 && start2 <= end2)
        {
            if (str1[start1] != str2[start2])
            {
                return false;
            }
            start1++;
            start2++;
        }
        return true;
    }
}