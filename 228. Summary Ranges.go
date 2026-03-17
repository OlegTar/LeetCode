/*You are given a sorted unique integer array nums.

A range [a,b] is the set of all integers from a to b (inclusive).

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

"a->b" if a != b
"a" if a == b
 

Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"
Example 2:

Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
 

Constraints:

0 <= nums.length <= 20
-231 <= nums[i] <= 231 - 1
All the values of nums are unique.
nums is sorted in ascending order.*/
import (
    "strings"
    "strconv"
)
func summaryRanges(nums []int) []string {
    if (len(nums) == 0) {
        return []string{}
    }

    var result []string
    var sb strings.Builder
    sb.WriteString(strconv.Itoa(nums[0]))

    sequence := false
    last := nums[0]

    for i := 1; i < len(nums); i++ {
        if (nums[i] == nums[i - 1] + 1) {
            if (!sequence) {
                sb.WriteString("->")
                sequence = true
            }
            last = nums[i]
        } else {
            if (sequence) {
                sb.WriteString(strconv.Itoa(last))
                sequence = false
            }
            result = append(result, sb.String())
            sb.Reset()
            sb.WriteString(strconv.Itoa(nums[i]))
        }      
    }

    if (sequence) {
        sb.WriteString(strconv.Itoa(last))
    }
    result = append(result, sb.String())
    return result
}
