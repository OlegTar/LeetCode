/*
Given an integer number n, return the difference between the product of its digits and the sum of its digits.
 

Example 1:

Input: n = 234
Output: 15 
Explanation: 
Product of digits = 2 * 3 * 4 = 24 
Sum of digits = 2 + 3 + 4 = 9 
Result = 24 - 9 = 15
Example 2:

Input: n = 4421
Output: 21
Explanation: 
Product of digits = 4 * 4 * 2 * 1 = 32 
Sum of digits = 4 + 4 + 2 + 1 = 11 
Result = 32 - 11 = 21
 

Constraints:

1 <= n <= 10^5
 

*/
public class Solution {
    public int SubtractProductAndSum(int n) {
        var (product, sum) = (1, 0);
        foreach (var digit in GetDigits(n))
        {
            product *= digit;
            sum += digit;
        }
        return product - sum;
    }

    IEnumerable<int> GetDigits(int n)
    {
        while (n > 0)
        {
            yield return n % 10;
            n /= 10;
        }
    }
}
