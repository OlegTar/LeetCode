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
        var result = new List<int>();
        Pass(root1, result);
        Pass(root2, result);
        
        result.Sort();
        return result;
    }

    public void Pass(TreeNode node, List<int> result)
    {
        if (node == null)
        {
            return;
        }
        result.Add(node.val);
        Pass(node.left, result);
        Pass(node.right, result);
    }
}
