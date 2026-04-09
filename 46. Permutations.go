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
import "slices"
func permute(nums []int) [][]int {
    result := [][]int{}
    solve(0, nums, map[int]struct{}{}, &[]int{}, &result)
    return result;
}

func solve(start int, nums []int, used map[int]struct{}, comb *[]int, result *[][]int) {
    if (start == len(nums)) {
        //tmp := make([]int, len(*comb));
        // for ind, v := range(*comb) {
        //     tmp[ind] = v;
        // }
        tmp := slices.Clone(*comb)
        *result = append(*result, tmp);
        return;
    }

    for i := 0; i < len(nums); i++ {
        if _, ok := used[nums[i]]; ok {
            continue;
        }

        used[nums[i]] = struct{}{}
        *comb = append(*comb, nums[i])

        solve(start + 1, nums, used, comb, result)

        *comb = (*comb)[:len(*comb) - 1]
        delete(used, nums[i])
    }
}
