// See https://aka.ms/new-console-template for more information

public class BadSolution
{
    public bool Exist(char[][] board, string word)
    {
        var dict = new Dictionary<char, List<Point>>();

        for (int i = 0; i < word.Length; i++)
        {
            dict.TryAdd(word[i], new List<Point>());
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                var sym = board[i][j];
                if (dict.TryGetValue(sym, out List<Point> temp))
                {
                    temp.Add(new Point { X = i, Y = j, CanIUseThisPoint = true }); //true means: the point is free, you can use it
                }
            }
        }

        return IsThereWord(word, dict);
    }

    private bool IsThereWord(string word, Dictionary<char, List<Point>> dict)
    {
        var index = 0;
        var currentChar = word[index];
        var result = false;
        foreach (var point in dict[currentChar])
        {
            if (point.CanIUseThisPoint)
            {
                point.CanIUseThisPoint = false;
                result = CheckConnectionWithPoint(word, index + 1, dict, point);

                point.CanIUseThisPoint = true;
                if (result)
                    return true;
            }
        }
        return result;
    }

    private bool CheckConnectionWithPoint(string word, int index, Dictionary<char, List<Point>> dict, Point previousPoint)
    {
        if (index == word.Length)
        {
            return true;
        }

        var currentChar = word[index];
        var connectionBetweenPoint = false;
        foreach (var point in dict[currentChar])
        {
            if (point.CanIUseThisPoint)
            {
                point.CanIUseThisPoint = false;
                if ((previousPoint.X == point.X && Math.Abs(previousPoint.Y - point.Y) == 1) 
                    || (previousPoint.Y == point.Y && Math.Abs(previousPoint.X - point.X) == 1))
                {
                    connectionBetweenPoint = CheckConnectionWithPoint(word, index + 1, dict, point);
                }
                point.CanIUseThisPoint = true;
                if (connectionBetweenPoint)
                    return true;
            }
        }
        return connectionBetweenPoint;
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool CanIUseThisPoint { get; set; }
    }
}
