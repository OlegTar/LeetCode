/*Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y, return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.

Two nodes of a binary tree are cousins if they have the same depth with different parents.

Note that in a binary tree, the root node is at the depth 0, and children of each depth k node are at the depth k + 1.

 

Example 1:


Input: root = [1,2,3,4], x = 4, y = 3
Output: false
Example 2:


Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
Output: true
Example 3:


Input: root = [1,2,3,null,4], x = 2, y = 3
Output: false
 

Constraints:

The number of nodes in the tree is in the range [2, 100].
1 <= Node.val <= 100
Each node has a unique value.
x != y
x and y are exist in the tree.*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        Dictionary<int, List<(int val, int row)>> columns = new();
        Fill(root, 0, 0, columns);
        var result = new List<IList<int>>();
        foreach (var column in columns.Keys.OrderBy(k => k))
        {           
            columns[column].Sort((a, b) => {
                if (a.row == b.row) 
                {
                    return a.val.CompareTo(b.val);
                }
                return a.row.CompareTo(b.row);
            });
            result.Add(columns[column].Select(a => a.val).ToList());
        }
        return result;
    }

    public void Fill(TreeNode node, int row, int column, Dictionary<int, List<(int val, int row)>> columns)
    {
        if (node == null)
        {
            return;
        }

        columns.TryAdd(column, []);
        columns[column].Add((node.val, row));
        Fill(node.left, row + 1, column - 1, columns);
        Fill(node.right, row + 1, column + 1, columns);
    }
}
