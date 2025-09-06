public class Solution {
    public int Search(int[] nums, int target) 
    {
        var left = 0;
        var right = nums.Length - 1;
        var maxIndex = 0;
        while (left <= right)
        {            
            var mid = left + (right - left) / 2;
                       
            if (nums[mid] >= nums[maxIndex])
            {
                maxIndex = mid;
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        //var k = nums.Length - 1 - maxIndex;        
        //var offsetToRight = nums.Length - k;        
        var offsetToRight = 1 + maxIndex;

        left = 0;
        right = nums.Length;
        var index = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midWithOffset = (mid + offsetToRight) % nums.Length;

            if (nums[midWithOffset] == target)
            {
                index = midWithOffset;
                break;
            }
            else if (nums[midWithOffset] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return index;       
    }
}
