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
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        var parentOfSlidePtr = head;
        var slidePtr = head.next;
        while(slidePtr != null)
        {
            var t = slidePtr.next;
            slidePtr.next = parentOfSlidePtr;
            parentOfSlidePtr = slidePtr;
            slidePtr = t;
        }
        head.next = null;
        
        return parentOfSlidePtr;
    }
    //public ListNode ReverseList(ListNode head)
    //{
    //    if (head == null || head.next == null)
    //        return head;
    //    var r = ReverseList(head, head.next);
    //    head.next = null;
    //    return r;
    //}

    //private ListNode ReverseList(ListNode previous, ListNode current)
    //{
    //    ListNode previo = null;
    //    if (current.next != null)
    //        previo = ReverseList(current, current.next);
    //    current.next = previous;
    //    return previo ?? current;
    //}
}

public partial class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var ptr = head;
        while (ptr != null && ptr.next != null)
        {
            if (ptr.val == ptr.next.val)
            {
                ptr.next = ptr.next.next;
            }
            else
                ptr = ptr.next;
        }
        return head;
    }
}
