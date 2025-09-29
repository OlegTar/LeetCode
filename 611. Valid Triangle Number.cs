public class Solution {
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length - 3;        
        var total = 0;
        var i = 0;
        for (; i <= n && nums[i] == 0; i++);

        for (; i <= n; i++)
        {
            var a = nums[i];
            var n2 = n + 1;
            for (var j = i + 1; j <= n2; j++)
            {
                var b = nums[j];
                var sum = a + b;

                var left = i + 2;
                var right = nums.Length - 1;            
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (nums[mid] >= sum)
                    {
                        right = mid - 1;
                    }
                    else if (nums[mid] < sum)
                    {
                        left = mid + 1;
                    }
                }
                
                total += left - 1 - j;
            }            
        }

        return total;
    }
}
