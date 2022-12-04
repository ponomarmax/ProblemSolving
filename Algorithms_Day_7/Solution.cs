public partial class Solution
{
    //int[] directions = new int[] { 0, 1, 0, -1, 0 };
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {

        var valueToFind = image[sr][sc];
        if (valueToFind == color)
            return image;
        DFS(image, sr, sc, valueToFind, color);
        return image;
    }

    private void DFS(int[][] origin, int sr, int sc, int sourceValue, int targetValue)
    {
        if (origin.Length <= sr || sr < 0 || origin[0].Length <= sc || sc < 0 || origin[sr][sc] != sourceValue)
            return;
        origin[sr][sc] = targetValue;

        for (int i = 0; i < directions.Length - 1; i++)
        {
            DFS(origin, sr + directions[i], sc + directions[i + 1], sourceValue, targetValue);
        }
    }

    private void BFS(int[][] origin, IList<(int, int)> checkNeighbours, int sourceValue, int targetValue)
    {
        for (int j = 0; j < checkNeighbours.Count; j++)
        {
            var neighbour = checkNeighbours[j];
            origin[neighbour.Item1][neighbour.Item2] = targetValue;
            for (int i = 0; i < directions.Length - 1; i++)
            {
                var r = neighbour.Item1 + directions[i];
                var c = neighbour.Item2 + directions[i + 1];
                if (origin.Length > r && r >= 0 && origin[0].Length > c && c >= 0)
                {
                    if (origin[r][c] == sourceValue)
                    {
                        checkNeighbours.Add((r, c));
                    }
                }
            }
        }
        return;
    }
}

public partial class Solution
{
    int[] directions = new int[] { 0, 1, 0, -1, 0 };

    public int MaxAreaOfIsland(int[][] grid)
    {
        var maxSum = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    var sum = 0;
                    DFS(grid, i, j, ref sum);
                    if(sum > maxSum)
                        maxSum = sum;
                }
            }
        }
        return maxSum;
    }

    private void DFS(int[][] origin, int sr, int sc, ref int currentSum)
    {
        if (origin.Length <= sr || sr < 0 || origin[0].Length <= sc || sc < 0 || origin[sr][sc] != 1)
            return;

        currentSum++;
        origin[sr][sc] = -1;
        for (int i = 0; i < directions.Length - 1; i++)
        {
            DFS(origin, sr + directions[i], sc + directions[i + 1], ref currentSum);
        }
    }
}