// See https://aka.ms/new-console-template for more information
using System.Collections;

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        var hashTable = new HashSet<string>();
        char symbol;

        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                symbol = board[x][y];
                if (symbol != '.')
                {
                    if (!hashTable.Add($"row{symbol}{x}"))
                        return false;
                    if (!hashTable.Add($"column{symbol}{y}"))
                        return false;
                    if (!hashTable.Add($"box{symbol}{3 * (x / 3) + y / 3}"))
                        return false;
                }
            }
        }
        return true;
    }
}
