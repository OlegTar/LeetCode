public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;

        var left = nums.Length;
        var right = -1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                left = mid;
                if (mid > right)
                {
                    right = mid;
                }

                end = mid - 1;
            }
            else if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        if (right == -1)
        {
            return [-1, -1];
        }

        start = right;
        end = nums.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                right = mid;
                start = mid + 1;
            }
            else if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        return [left, right];
    }
}
