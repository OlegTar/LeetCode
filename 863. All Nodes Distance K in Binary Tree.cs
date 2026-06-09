/*
Given the root of a binary tree, the value of a target node target, and an integer k, return an array of the values of all nodes that have a distance k from the target node.

You can return the answer in any order.

 

Example 1:


Input: root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, k = 2
Output: [7,4,1]
Explanation: The nodes that are a distance 2 from the target node (with value 5) have values 7, 4, and 1.
Example 2:

Input: root = [1], target = 1, k = 3
Output: []
 

Constraints:

The number of nodes in the tree is in the range [1, 500].
0 <= Node.val <= 500
All the values Node.val are unique.
target is the value of one of the nodes in the tree.
0 <= k <= 1000*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Dictionary<TreeNode, (bool left, bool right)> map = new();
        MakeMap2(root, map, target.val);
        
        var distanceFromRoot = 0;
        var node = root;
        
        while (node != target)
        {
            if (map[node].left)
            {
                node = node.left;
            } 
            else 
            {
                node = node.right;
            }
            
            distanceFromRoot++;
        }
        
        var result= new List<int>();
        //Console.WriteLine(distanceFromRoot);
//Console.WriteLine("left =" + map[root].left);
//Console.WriteLine("right =" + map[root].right);
        Solve(map, root, distanceFromRoot, k, result);
        
        return result;
    }
    
    public void MakeMap2(TreeNode node, Dictionary<TreeNode, (bool left, bool right)> map, int target)
    {
        if (node == null)
        {
            return;
        }
        
        if (!map.ContainsKey(node))
        {
            MakeMap(node, map, target);
        }
        
        MakeMap2(node.left, map, target);
        MakeMap2(node.right, map, target);
    }
    
    public bool MakeMap(TreeNode node, Dictionary<TreeNode, (bool left, bool right)> map, int target)
    {
        if (node == null)
        {
            return false;
        }
        
        if (node.val == target)
        {
            map[node] = (false, false);
            return true;
        }
        
        if (MakeMap(node.left, map, target))
        {
            map[node] = (true, false);
            return true;
        }
        
        if (MakeMap(node.right, map, target))
        {
            map[node] = (false, true);
            return true;
        }
        
        map[node] = (false, false);
        return false;
    }
    
    public void Solve(Dictionary<TreeNode, (bool left, bool right)> map, TreeNode node, int distance, int k, List<int> result)
    {
        if (node == null)
        {
            return;
        }
        
        if (distance == k)
        {
            result.Add(node.val);
        }
        
        if (distance >= k)
        {
            if (map[node].left)
            {
                Solve(map, node.left, distance - 1, k, result);
            }
            
            
            if (map[node].right)
            {
                Solve(map, node.right, distance - 1, k, result);
            }
        }
        else 
        { 
            if (map[node].left)
            {
                Solve(map, node.left, distance - 1, k, result);
            }
            else
            {
                Solve(map, node.left, distance + 1, k, result);
            }
            
            if (map[node].right)
            {
                Solve(map, node.right, distance - 1, k, result);
            }
            else
            {
                Solve(map, node.right, distance + 1, k, result);
            }
        }
    }
}
