var result = Result.encryption("iffactsdontfittotheorychangethefacts");

var expected = "isieae fdtonf fotrga anoyec cttctt tfhhhs";

Console.WriteLine($"Result: {result}");
Console.WriteLine($"Expected: {expected}");
Console.WriteLine($"Is expected value equals to result: {expected == result}");

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        s = s.Replace(" ", "");
        var sLength = s.Length;
        var rowCount = (int)Math.Sqrt(sLength);
        int columnCount;

        if (rowCount * rowCount == sLength) columnCount = rowCount;
        else if (rowCount * (rowCount + 1) >= sLength) columnCount = rowCount + 1;
        else
        {
            rowCount++;
            columnCount = rowCount;
        }

        var newString = "";
        for (var i = 0; i < columnCount; i++)
        {
            for (var j = 0; j < rowCount; j++)
            {
                if (i + j * columnCount < sLength) newString += s[i + j * columnCount];
                else break;
                
            }

            newString += " ";
        }

        return newString.TrimEnd();
    }


}