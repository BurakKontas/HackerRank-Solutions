var sol = new Solution();
var res = sol.SortJumbled([8, 9, 4, 0, 2, 1, 3, 5, 7, 6], [991, 338, 38]);

int[] expected = [338, 38, 991];

Console.WriteLine(string.Join(", ", res));
Console.WriteLine(string.Join(", ", expected));

public class Solution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        var mappedNumbers = nums.Select(num =>
        {
            var mappedValue = 0;
            var strNum = num.ToString();
            for (var j = 0; j < strNum.Length; j++)
            {
                mappedValue = mappedValue * 10 + mapping[int.Parse(strNum[j].ToString())];
            }
            return (original: num, mapped: mappedValue);
        }).ToList();

        var sortedMappedNumbers = MergeSort(mappedNumbers);

        return sortedMappedNumbers.Select(x => x.original).ToArray();
    }

    private List<(int original, int mapped)> MergeSort(List<(int original, int mapped)> list)
    {
        if (list.Count <= 1)
            return list;

        var mid = list.Count / 2;
        var left = MergeSort(list.GetRange(0, mid));
        var right = MergeSort(list.GetRange(mid, list.Count - mid));

        return Merge(left, right);
    }

    private List<(int original, int mapped)> Merge(List<(int original, int mapped)> left, List<(int original, int mapped)> right)
    {
        var result = new List<(int original, int mapped)>();
        int i = 0, j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i].mapped <= right[j].mapped)
                result.Add(left[i++]);
            else
                result.Add(right[j++]);
        }

        result.AddRange(left.GetRange(i, left.Count - i));
        result.AddRange(right.GetRange(j, right.Count - j));

        return result;
    }
}
