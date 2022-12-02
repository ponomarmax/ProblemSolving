// See https://aka.ms/new-console-template for more information

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public partial class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        var current = head;
        var middle = current;
        var counter = 0;
        while (current.next != null)
        {
            counter++;
            current = current.next;
            if(counter % 2 == 1)
                middle= middle.next;

        }
       
        return middle;
    }
}

