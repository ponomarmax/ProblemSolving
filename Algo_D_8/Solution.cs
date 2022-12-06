using System.Xml.Linq;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public partial class Solution
{
    //iterative with modifining a first tree
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null) return root2;
        if (root2 == null) return root1;
        var stack = new Stack<TreeNode[]>();
        stack.Push(new TreeNode[] { root1, root2 });
        while (stack.Any())
        {
            var pair = stack.Pop();
            var (one, two) = (pair[0], pair[1]);
            if (two == null)
                continue;

            one.val += two.val;
            if (one.left == null)
                one.left = two.left;
            else
                stack.Push(new TreeNode[] { one.left, two.left });

            if (one.right == null)
                one.right = two.right;
            else
                stack.Push(new TreeNode[] { one.right, two.right });
        }

        return root1;
    }

    ////recursive with modifining a first tree
    //public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    //{
    //    if (root1 == null) return root2;
    //    if (root2 == null) return root1;
    //    root1.val += root2.val;
    //    root1.left = MergeTrees(root1.left, root2.left);
    //    root1.right = MergeTrees(root1.right, root2.right);
    //    return root1;
    //}

    //// recursive with creating a new tree
    //public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    //{
    //    TreeNode? final = null;
    //    MergeTrees(root1, root2, ref final);
    //    return final;
    //}
    //private void MergeTrees(TreeNode root1, TreeNode root2, ref TreeNode? final)
    //{
    //    if (root1 == null && root2 == null) return;
    //    var finalValue = (root1?.val ?? 0) + (root2?.val ?? 0);
    //    final = new TreeNode(finalValue);
    //    MergeTrees(root1?.left, root2?.left, ref final.left);
    //    MergeTrees(root1?.right, root2?.right, ref final.right);
    //}
}


// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public partial  class Solution
{
    public Node Connect(Node root)
    {
        return Traver(root, null);
    }

    private Node Traver(Node current, Node rightNeighbour)
    {
        if (current == null)
            return null;
        if (rightNeighbour != null)
        {
            current.next = rightNeighbour;
            rightNeighbour = rightNeighbour.left;
        }
        rightNeighbour = Traver(current.right, rightNeighbour);
        _ = Traver(current.left, rightNeighbour);
        return current;
    }
}