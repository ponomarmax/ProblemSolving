public partial class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (var item in s)
        {
            if (item == '[' || item == '(' || item == '{')
            {
                stack.Push(item);
            }
            else
            {
                if (item == ']' && (!stack.TryPop(out char symbol) || symbol != '[')) return false;
                if (item == '}' && (!stack.TryPop(out symbol) || symbol != '{')) return false;
                if (item == ')' && (!stack.TryPop(out symbol) || symbol != '(')) return false;
            }

        }
        return !stack.Any();
    }
}
