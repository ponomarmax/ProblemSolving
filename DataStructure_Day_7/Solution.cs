public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public partial class Solution
{
    public bool HasCycle(ListNode head)
    {
        var fast = head;
        var slow = head;
        while (true)
        {
            fast = fast?.next?.next;
            slow = slow?.next;
            if (fast == null)
                return false;
            if (slow == fast)
                return true;
        }
    }
}

public partial class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        ListNode main = list1;
        if (list1.val > list2.val)
        {
            main = list2;
            list2 = list2.next;
        }
        else
        {
            list1 = list1.next;
        }
        var mainSlide = main;
        while (list1 != null && list2 != null)
        {
            MakeStepInMergeSorting(ref mainSlide, ref (list1.val > list2.val) ? ref list2 : ref list1);
        }
        if (list1 != null)
        {
            MakeStepInMergeSorting(ref mainSlide, ref list1);
        }
        else if (list2 != null)
        {
            MakeStepInMergeSorting(ref mainSlide, ref list2);
        }

        return main;
    }

    private void MakeStepInMergeSorting(ref ListNode mainSlidePointer, ref ListNode listPointer)
    {
        mainSlidePointer.next = listPointer;
        mainSlidePointer = mainSlidePointer.next;
        listPointer = listPointer.next;
    }
}

public partial class Solution
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;
        }
        var slidePtr = head;

        while (slidePtr != null)
        {
            if (slidePtr.next?.val == val)
            {
                slidePtr.next = slidePtr.next?.next;
            }
            else
            {
                slidePtr = slidePtr.next;
            }
        }
        return head;
    }
}

