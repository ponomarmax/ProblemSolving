public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        var result = new int[mat.Length][];
        var maxValue = int.MaxValue - 100000;

        for (int i = 0; i < mat.Length; ++i)
        {
            result[i] = new int[mat[0].Length];
            for (int j = 0; j < mat[0].Length; ++j)
            {
                result[i][j] = maxValue;
            }
        }

        for (int i = 0; i < mat.Length; ++i)
        {
            for (int j = 0; j < mat[0].Length; ++j)
            {
                if (mat[i][j] == 0)
                    result[i][j] = 0;
                else
                {
                    if (i > 0)
                        result[i][j] = Math.Min(result[i - 1][j] + 1, result[i][j]);
                    if (j > 0)
                        result[i][j] = Math.Min(result[i][j - 1] + 1, result[i][j]);
                }
            }
        }

        for (int i = mat.Length - 1; i >= 0; --i)
        {
            for (int j = mat[0].Length - 1; j >= 0; --j)
            {
                if (i < mat.Length - 1)
                    result[i][j] = Math.Min(result[i + 1][j] + 1, result[i][j]);
                if (j < mat[0].Length - 1)
                    result[i][j] = Math.Min(result[i][j + 1] + 1, result[i][j]);
            }
        }
        return result;
    }
}