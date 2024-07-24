using System.Numerics;

Result.extraLongFactorials(25);

// expected: 15511210043330985984000000

class Result
{

    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
        BigInteger result = 1;
        while (n > 0)
        {
            result *= n--;
        }

        Console.WriteLine(result);
    }

}