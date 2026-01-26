/*Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:


 

Example 1:

Input: rowIndex = 3
Output: [1,3,3,1]
Example 2:

Input: rowIndex = 0
Output: [1]
Example 3:

Input: rowIndex = 1
Output: [1,1]
 

Constraints:

0 <= rowIndex <= 33
 

Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?*/
class Solution {
    public List<Integer> getRow(int rowIndex) {
        List<Integer> prev = new ArrayList<>();
        List<Integer> current = new ArrayList<>();
        for (int i = 0; i <= rowIndex; i++)
        {
            current = new ArrayList<>();
            for (int j = 0; j <= i; j++) {
                current.add(1);
            }
            for (int j = 1; j < current.size() - 1; j++) {
                current.set(j, prev.get(j - 1) + prev.get(j));
            }
            prev = current;
        }

        return current;
    }
}
