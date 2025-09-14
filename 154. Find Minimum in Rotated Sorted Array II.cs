public class Solution {
    public int FindMin(int[] nums) {
        return Solve(0, nums.Length - 1, nums, nums[^1]);
    }

    public int Solve(int left, int right, int[] nums, int min)
    {
        while (left <= right && left >= 0 && left < nums.Length && right >= 0 && right < nums.Length)
        {
            var mid = left + (right - left) / 2;
            
            if (nums[mid] < min)
            {
                min = nums[mid];
                right = mid - 1;
            }
            else if (nums[mid] > min)
            {
                left = mid + 1;
            }
            else 
            {
                var minRight = Solve(mid + 1, right, nums, min);
                if (minRight < min)
                {
                    return minRight;
                }

                return Solve(left, mid - 1, nums, min);
            }
        }
        return min;
    }
}
