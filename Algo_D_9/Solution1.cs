/// <summary>
/// https://leetcode.com/problems/01-matrix
/// this solution is quite complex
/// </summary>
public class Solution1
{
    int[] calcPaths = new int[] { 0, 1, 0, -1, 0 };
    const int OUT_OF_MATRIX = 200000;
    const int ALREADY_VISITED_NODE = 100000;
    public int[][] UpdateMatrix(int[][] mat)
    {
        for (int i = 0; i < mat.Length; ++i)
        {
            for (int j = 0; j < mat[i].Length; ++j)
            {
                if (mat[i][j] == 1)
                {
                    FindShortPath(mat, i, j, mat.Length + mat[i].Length - 2);
                }
            }
        }

        for (int i = 0; i < mat.Length; ++i)
        {
            for (int j = 0; j < mat[i].Length; ++j)
            {
                mat[i][j] *= -1;
            }
        }
        return mat;
    }

    private int FindShortPath(int[][] origin, int r, int c, int currentMin)
    {
        if (IsWrongIndex(origin, r, c)) // int.MaxValue is already visited
            return OUT_OF_MATRIX; // code for outbound
        if (origin[r][c] == ALREADY_VISITED_NODE) return ALREADY_VISITED_NODE; // code for visited 
        if (origin[r][c] <= 0) return origin[r][c] * -1;
        if (currentMin < 0) return OUT_OF_MATRIX;

        origin[r][c] = ALREADY_VISITED_NODE;
        var minPathValue = int.MaxValue;
        var wasBorderCrossed = false;
        --currentMin;
        for (int i = 0; i < calcPaths.Length - 1; ++i)
        {
            var result = FindShortPath(origin, r + calcPaths[i], c + calcPaths[i + 1], Math.Min(minPathValue, currentMin));
            if (result < minPathValue) minPathValue = result;
            if (minPathValue == 0) break;
            if (result == ALREADY_VISITED_NODE) wasBorderCrossed = true;
        }

        if (minPathValue >= OUT_OF_MATRIX)
        {
            origin[r][c] = 1;
            return OUT_OF_MATRIX;
        }

        var returnResult = minPathValue + 1;
        origin[r][c] = wasBorderCrossed ? 1 : returnResult * -1;
        return returnResult;
    }

    private bool IsWrongIndex(int[][] origin, int r, int c) => r >= origin.Length || r < 0 || c >= origin[0].Length || c < 0;
}