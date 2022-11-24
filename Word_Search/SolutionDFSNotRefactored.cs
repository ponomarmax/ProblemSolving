public class SolutionDFSNotRefactored
{
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
        if (index + 1 == word.Length)
        {
            return true;
        }
        var currentChar = word[index];
        var nextChar = word[index + 1];
        var result = false;
        board[j][i] = '#';
        Display(board);
        if (i + 1 < board[j].Length && board[j][i + 1] == nextChar)
        {
            result = DFS(board, word, index + 1, j, i + 1);
        }
        if (!result && i - 1 >= 0 && board[j][i - 1] == nextChar)
        {
            result = DFS(board, word, index + 1, j, i - 1);
        }
        if (!result && j + 1 < board.GetLength(0) && board[j + 1][i] == nextChar)
        {
            result = DFS(board, word, index + 1, j + 1, i);
        }
        if (!result && j - 1 >= 0 && board[j - 1][i] == nextChar)
        {
            result = DFS(board, word, index + 1, j - 1, i);
        }
        board[j][i] = currentChar;
        return result;
    }

    private void Display(char[][] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                Console.Write($"{board[i][j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("================");
    }
}
