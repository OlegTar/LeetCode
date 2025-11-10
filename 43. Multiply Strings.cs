/*43. Multiply Strings
Solved
Medium
Topics
premium lock icon
Companies
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

 

Example 1:

Input: num1 = "2", num2 = "3"
Output: "6"
Example 2:

Input: num1 = "123", num2 = "456"
Output: "56088"
 

Constraints:

1 <= num1.length, num2.length <= 200
num1 and num2 consist of digits only.
Both num1 and num2 do not contain any leading zero, except the number 0 itself.*/

public class Solution {
    public string Multiply(string num1, string num2) {
        var result = new int[num1.Length + num2.Length];
        var temp = new int[num1.Length + num2.Length];
        for (var i = 0; i < num2.Length; i++)
        {
            Array.Fill(temp, 0);
            var digitNum2 = num2[^(i + 1)] - '0';
            var overflow = 0;
            for (var j = 0; j < num1.Length; j++)
            {
                var digitNum1 = num1[^(j + 1)] - '0';
                var mult = digitNum1 * digitNum2 + overflow;
                overflow = mult / 10;
                temp[^(j + 1 + i)] = mult % 10; 
            }
            
            temp[^(num1.Length + 1 + i)] = overflow;
            var n = num1.Length + 1 + i;
            overflow = 0;

            for (var j = 1; j <= n; j++)
            {
                var digitTemp = temp[^j];
                var digitResult = result[^j]; 
                var sum = digitTemp + digitResult + overflow;
                result[^j] = sum % 10;
                overflow = sum >= 10 ? 1 : 0;
            }
        }
    
        var k = 0;
        while (k < result.Length && result[k] == 0)
        {
            k++;
        }

        if (k == result.Length && result[^1] == 0)
        {
            return "0";
        }

        var sb = new StringBuilder();
        while (k < result.Length) 
        {
            sb.Append(result[k].ToString());
            k++;
        }

        return sb.ToString();
    } 
}
