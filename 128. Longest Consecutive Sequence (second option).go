/*Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

 

Example 1:

Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
Example 2:

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
Example 3:

Input: nums = [1,0,1,2]
Output: 3
 

Constraints:

0 <= nums.length <= 105
-109 <= nums[i] <= 109*/
func longestConsecutive(nums []int) int {
    if (len(nums) <= 1) {
        return len(nums);
    }

    hash := map[int]struct{}{}
    for _, num := range(nums) {
        hash[num] = struct{}{}
    }

    length := 1; 
    for _, num := range(nums) {
        if _, ok := hash[num - 1]; !ok {
            currentLen := 1
            nextNum := num + 1
            for j := 0; j < len(nums); j++ {
                if _, ok := hash[nextNum]; ok {
                    currentLen++
                } else {
                    break
                }
                nextNum++
            }
            
            length = max(length, currentLen)
            if (length > (len(nums) / 2)) {
                break;
            }
        }
    }

    return length
}
