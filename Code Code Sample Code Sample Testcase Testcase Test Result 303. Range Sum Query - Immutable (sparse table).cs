/*Given an integer array nums, handle multiple queries of the following type:

Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
Implement the NumArray class:

NumArray(int[] nums) Initializes the object with the integer array nums.
int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).
 

Example 1:

Input
["NumArray", "sumRange", "sumRange", "sumRange"]
[[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
Output
[null, 1, -1, -3]

Explanation
NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
numArray.sumRange(0, 2); // return (-2) + 0 + 3 = 1
numArray.sumRange(2, 5); // return 3 + (-5) + 2 + (-1) = -1
numArray.sumRange(0, 5); // return (-2) + 0 + 3 + (-5) + 2 + (-1) = -3*/

public class NumArray {
    private int[][] sparseTable;

    public NumArray(int[] nums) {
        var log2N = (int)Math.Log2(nums.Length);
        sparseTable = new int[log2N + 1][];
        sparseTable[0] = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            sparseTable[0][i] = nums[i];
        }

        for (var i = 1; i <= log2N; i++)
        {
            var len = nums.Length - (1 << i) + 1;
            sparseTable[i] = new int[len];
            for (var j = 0; j < len; j++)
            {
                sparseTable[i][j] = sparseTable[i - 1][j] + sparseTable[i - 1][j + (1 << (i - 1))];
            }
        }
    }
    
    public int SumRange(int left, int right) {
        var len = right - left + 1;
        var log2N = (int)Math.Log2(len);
        var sum = 0;
        while (len > 0)
        {
            while ((1 << log2N) > len)
            {
                log2N--;
            }
            var power2 = (1 << log2N);
            sum += sparseTable[log2N][left];
            left += power2;
            len -= power2;
        }
        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
