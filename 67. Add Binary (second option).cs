/*Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
 

Constraints:

1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.*/

public class Solution {
    public string AddBinary(string a, string b) {
        var result = new char[Math.Max(a.Length, b.Length) + 1];
        var n = result.Length - 1;
        var overflow = 0;
        for (var i = 1; i <= n; i++)
        {
            var digitA = i <= a.Length ? a[^i] - '0' : 0;
            var digitB = i <= b.Length ? b[^i] - '0' : 0;
            var sum = digitA + digitB + overflow;
            result[^i] = (char)((sum % 2) + '0');
            overflow = sum / 2;
        }

        if (overflow == 1)
        {
            result[^(n + 1)] = '1';
        }

        var start = result.Length - (n + overflow);
        return new string(result[start..result.Length]);
    }
}
