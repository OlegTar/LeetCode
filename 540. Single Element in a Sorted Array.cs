public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == nums[mid - 1])
            {
                var len = right - mid;
                
                if (len % 2 == 0)
                {
                    right = mid - 2;
                }
                else 
                {
                    left = mid + 1;
                }
            }
            else
            {
                var len = right - mid + 1;
                
                if (len % 2 == 0)
                {
                    right = mid - 1;
                }
                else 
                {
                    left = mid;
                }
            }
        }

        return nums[left];
    }
}
