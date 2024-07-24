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
        var res = new List<int>();

        var combined1 = v + " " + p;
        var combined2 = new string(v.Reverse().ToArray()) + " " + new string(p.Reverse().ToArray());

        var r1 = Rid(combined1);
        var r2 = Rid(combined2);

        for (var i = 0; i <= pLength - vLength; i++)
        {
            if (r1[vLength + 1 + i] == vLength || r1[vLength + i + 1] + r2[pLength + 1 - i] + 1 >= vLength)
                res.Add(i);
        }

        if (res.Count > 0)
            Console.WriteLine(string.Join(" ", res));
        else
            Console.WriteLine("No Match!");
    }

    private static int[] Rid(string s)
    {
        var n = s.Length;
        var a = 0;
        var b = 0;
        var r = new int[n];
        for (var i = 1; i < n; i++)
        {
            if (r[i - a] < b - i + 1)
                r[i] = r[i - a];
            else
            {
                a = i;
                b = Math.Max(i, b);
                while (b < n && s[b - a] == s[b])
                    b++;
                r[i] = b - a;
                b--;
            }
        }
        return r;
    }
}