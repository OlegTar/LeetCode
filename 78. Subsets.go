/*Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
Example 2:

Input: nums = [0]
Output: [[],[0]]
 

Constraints:

1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.*/
func subsets(nums []int) [][]int {
    result := [][]int{}
    solve(&result, []int{}, 0, nums);
    return result;
}

func solve(result *[][]int, subset []int, index int, nums []int) {
    if (index == len(nums)) {
        copy := []int{}
        // for _, el := range(*subset) {
        //     copy = append(copy, el);
        // }
        copy = append(copy, subset...)
        *result = append(*result, copy)
        return;
    }

    subset = append(subset, nums[index])
    solve(result, subset, index + 1, nums)
    subset = subset[:len(subset) - 1]
    solve(result, subset, index + 1, nums)
}
