using System;
using System.Collections;
using System.Collections.Generic;

namespace Reorder_List
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      ListNode head = new ListNode(1);
      head.next = new ListNode(2);
      head.next.next = new ListNode(3);
      head.next.next.next = new ListNode(4);
      head.next.next.next.next = new ListNode(5);
      //head.next.next.next.next.next = new ListNode(6);
      p.ReorderList(head);
      while (head != null)
      {
        Console.WriteLine(head.val);
        head = head.next;
      }
    }
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
    private void ReorderList(ListNode head)
    {
      ListNode copy = head;
      // to hold the linkded list data in reverse order
      // the idea is will take one node from input head and next node from stack (stack has the elements in reverse order)
      // question also asked us to link first node with last node, second with second last , third with third last and so on...
      Stack<int> stk = new Stack<int>();
      while (copy != null)
      {
        stk.Push(copy.val);
        copy = copy.next;
      }

      ListNode temp = head;
      bool isOdd = stk.Count % 2 != 0;
      // we need to loop only half elements
      int noOfIterations = (stk.Count / 2);
      while (noOfIterations > 0 && temp != null)
      {
        // store the next node to use it for next iteration.
        ListNode next = temp.next;
        // fetch the last , second last, thord last and so on in each iteration
        ListNode n2 = new ListNode(stk.Pop());
        // link first with last, second with second last and so on in each iteration
        temp.next = n2;
        // When total node count is even, no need to link the middle node and next node
        // thats why we set temp as null and break
        // e,g - 1 2 3 4 5 6
        // after 1 iteration - 1 6 | 2 3 4 5 6 temp at 2
        // after 2 iteration - 1 6 2 5 | 3 4 5 6 temp at 3
        // after 3 (last) iteration - 1 6 2 5 3 4 | 4 5 6 temp at 4, as this is the last iteration we set the temp as null.
        if (noOfIterations == 1 && !isOdd)
        {
          temp = null;
          return;
        }
        temp.next.next = next;
        temp = next;
        noOfIterations--;
      }
      temp.next = null;
    }
  }
}
