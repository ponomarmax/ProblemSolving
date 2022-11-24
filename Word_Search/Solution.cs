public class Solution
{
    private readonly int[] dirs = new int[] { 0, -1, 0, 1, 0 };
    public bool Exist(char[][] board, string word)
    {
        if (board.GetLength(0) * board[0].Length < word.Length)
        {
            return false;
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == word.First())
                {
                    if (DFS(board, word, 0, i, j))
                        return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int index, int j, int i)
    {
        if (index == word.Length)
        {
            return true;
        }
        if (j < 0 || j >= board.GetLength(0) || i < 0 || i >= board[0].Length)
        {
            return false;
        }
        if (board[j][i] == word[index])
        {
            board[j][i] = '#';
            for (int k = 0; k < dirs.Length - 1; k++)
            {
                if (DFS(board, word, index + 1, j + dirs[k], i + dirs[k + 1]))
                {
                    return true;
                }
            }
            board[j][i] = word[index];
        }
        return false;
    }
}
