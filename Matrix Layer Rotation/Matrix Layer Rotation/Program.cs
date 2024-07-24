Result.matrixRotation([
    [1, 2, 3, 4],
    [7, 8, 9, 10],
    [13, 14, 15, 16],
    [19, 20, 21, 22],
    [25, 26, 27, 28]
    //[6, 7],
    //[10, 11],
    ], 7);

// result 
// 3 4 8 12 
// 2 11 10 16
// 1 7 6 15
// 5 9 13 14

class Result
{

    /*
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        var rowCount = matrix.Count;
        var colCount = matrix[0].Count;
        var numLayers = Math.Min(rowCount, colCount) / 2;

        for (var layer = 0; layer < numLayers; layer++)
        {
            var elements = ExtractLayer(matrix, layer, rowCount, colCount);
            var rotationCount = r % elements.Count;
            RotateLayer(matrix, layer, rowCount, colCount, elements, rotationCount);
        }

        PrintMatrix(matrix);
    }

    private static List<int> ExtractLayer(List<List<int>> matrix, int layer, int rowCount, int colCount)
    {
        var elements = new List<int>();

        // Top row
        for (var col = layer; col < colCount - layer; col++)
        {
            elements.Add(matrix[layer][col]);
        }

        // Right column
        for (var row = layer + 1; row < rowCount - layer; row++)
        {
            elements.Add(matrix[row][colCount - layer - 1]);
        }

        // Bottom row
        for (var col = colCount - layer - 2; col >= layer; col--)
        {
            elements.Add(matrix[rowCount - layer - 1][col]);
        }

        // Left column
        for (var row = rowCount - layer - 2; row > layer; row--)
        {
            elements.Add(matrix[row][layer]);
        }

        return elements;
    }

    private static void RotateLayer(List<List<int>> matrix, int layer, int rowCount, int colCount, List<int> elements, int rotationCount)
    {
        var idx = 0;

        // Top row
        for (var col = layer; col < colCount - layer; col++)
        {
            matrix[layer][col] = elements[(idx + rotationCount) % elements.Count];
            idx++;
        }

        // Right column
        for (var row = layer + 1; row < rowCount - layer; row++)
        {
            matrix[row][colCount - layer - 1] = elements[(idx + rotationCount) % elements.Count];
            idx++;
        }

        // Bottom row
        for (var col = colCount - layer - 2; col >= layer; col--)
        {
            matrix[rowCount - layer - 1][col] = elements[(idx + rotationCount) % elements.Count];
            idx++;
        }

        // Left column
        for (var row = rowCount - layer - 2; row > layer; row--)
        {
            matrix[row][layer] = elements[(idx + rotationCount) % elements.Count];
            idx++;
        }
    }

    private static void PrintMatrix(List<List<int>> matrix)
    {
        var rows = matrix.Count;

        for (var i = 0; i < rows; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }

}