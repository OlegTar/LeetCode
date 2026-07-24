/*Given an array nums that represents a permutation of integers from 1 to n. We are going to construct a binary search tree (BST) by inserting the elements of nums in order into an initially empty BST. Find the number of different ways to reorder nums so that the constructed BST is identical to that formed from the original array nums.

For example, given nums = [2,1,3], we will have 2 as the root, 1 as a left child, and 3 as a right child. The array [2,3,1] also yields the same BST but [3,2,1] yields a different BST.
Return the number of ways to reorder nums such that the BST formed is identical to the original BST formed from nums.

Since the answer may be very large, return it modulo 109 + 7.

 

Example 1:


Input: nums = [2,1,3]
Output: 1
Explanation: We can reorder nums to be [2,3,1] which will yield the same BST. There are no other ways to reorder nums which will yield the same BST.
Example 2:


Input: nums = [3,4,5,1,2]
Output: 5
Explanation: The following 5 arrays will yield the same BST: 
[3,1,2,4,5]
[3,1,4,2,5]
[3,1,4,5,2]
[3,4,1,2,5]
[3,4,1,5,2]
Example 3:


Input: nums = [1,2,3]
Output: 0
Explanation: There are no other orderings of nums that will yield the same BST.
 

Constraints:

1 <= nums.length <= 1000
1 <= nums[i] <= nums.length
All integers in nums are distinct.*/
public class Solution {
    public int NumOfWays(int[] nums) {
        var c = new List<BigInteger>();
        c = NumOfWaysSub(nums, c);
        var x = new BigInteger(1);

        foreach (var number in c)
        {
            x *= number;
        }

        x = (x - 1) % 1_000_000_007;

        return (int)x;
    }

    private static List<BigInteger> NumOfWaysSub(int[] tree, List<BigInteger> c)
    {

        if (tree.Length <= 1) return c;

        var (left, right) = DivideTree(tree);
        c.Add(C(tree.Length - 1, left.Length));

        NumOfWaysSub(left, c);
        NumOfWaysSub(right, c);

        return c;
    }

    private static (int[] left, int[] right) DivideTree(int[] tree)
    {
        var leftTree = new List<int>();
        var rightTree = new List<int>();

        var root = tree[0];

        if (tree.Length == 2)
        {
            if (root > tree[1]) return (new[] { tree[1] }, new int[] { });
            return (new int[] { }, new[] { tree[1] });
        }

        for (var i = 1; i < tree.Length; i++)
        {
            if (root > tree[i])
            {
                leftTree.Add(tree[i]);
                continue;
            }
            rightTree.Add(tree[i]);
        }

        return (leftTree.ToArray(), rightTree.ToArray());
    }

    public static BigInteger C(int n, int k)
    {
        if (k == 1) return n;
        if (k == 0) return 1;
        if (n - k == 1) return n;

        var result = new BigInteger(1);

        for(var i = 1; i<= k; i++){
            result = result * (n - i + 1) / i;
        }

        return result;
    }
}
