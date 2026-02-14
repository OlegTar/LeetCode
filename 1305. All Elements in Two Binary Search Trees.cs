/*Given two binary search trees root1 and root2, return a list containing all the integers from both trees sorted in ascending order.

 

Example 1:


Input: root1 = [2,1,4], root2 = [1,0,3]
Output: [0,1,1,2,3,4]
Example 2:


Input: root1 = [1,null,8], root2 = [8,1]
Output: [1,1,8,8]
 

Constraints:

The number of nodes in each tree is in the range [0, 5000].
-105 <= Node.val <= 105*/
public class Solution {
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        var pq = new PriorityQueue<int, int>();
        Pass(root1, pq);
        Pass(root2, pq);
        
        var result = new List<int>();
        while (pq.Count > 0)
        {
            result.Add(pq.Dequeue());
        }
        return result;
    }

    public void Pass(TreeNode node, PriorityQueue<int, int> pq)
    {
        if (node == null)
        {
            return;
        }
        pq.Enqueue(node.val, node.val);
        Pass(node.left, pq);
        Pass(node.right, pq);
    }
}
