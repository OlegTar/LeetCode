public class Solution {
    public int FindMin(int[] nums) {
        var currentMin = nums[^1];
        var stack = new Stack<(int left, int right, int min)>();
        stack.Push((0, nums.Length - 1, currentMin));
        
        while (stack.Count() > 0)
        {
            var (left, right, min) = stack.Pop();

            if (min > currentMin)
            {
                continue;
            }

            while (left <= right && left >= 0 && left < nums.Length && right >= 0 && right < nums.Length)
            {
                var mid = left + (right - left) / 2;
                
                if (nums[mid] < currentMin)
                {
                    currentMin = nums[mid];
                    right = mid - 1;
                }
                else if (nums[mid] > currentMin)
                {
                    left = mid + 1;
                }
                else 
                {
                    stack.Push((left, mid - 1, currentMin));
                    stack.Push((mid + 1, right, currentMin));                    
                    break;
                }
            }
        }

        return currentMin;
    }    
}
