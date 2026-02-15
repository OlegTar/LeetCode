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
        List<int> list1 = new();
        Pass(root1, list1);
        List<int> list2 = new();
        Pass(root2, list2);
        
        var result = new int[list1.Count + list2.Count];
        int pointer1 = 0;
        int pointer2 = 0;
        int pointer = 0;
        while (pointer1 < list1.Count && pointer2 < list2.Count)
        {
            if (list1[pointer1] < list2[pointer2])
            {
                result[pointer++] = list1[pointer1++];
            }
            else
            {
                result[pointer++] = list2[pointer2++];
            }
        }

        if (pointer1 == list1.Count)
        {
            for (int i = pointer2; i < list2.Count; i++)
            {
                result[pointer++] = list2[i];
            }
        }

        if (pointer2 == list2.Count)
        {
            for (int i = pointer1; i < list1.Count; i++)
            {
                result[pointer++] = list1[i];
            }
        }


        return result;
    }

    public void Pass(TreeNode node, List<int> list)
    {
        if (node == null)
        {
            return;
        }
        Pass(node.left, list);
        list.Add(node.val);
        Pass(node.right, list);
    }
}
