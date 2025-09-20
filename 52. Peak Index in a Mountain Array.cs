public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        var left = 0;
        var right = arr.Length - 1;
        
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            
            if ((mid > 0 && mid < (arr.Length - 1)) && arr[mid - 1] < arr[mid] && arr[mid] > arr[mid + 1])
            {
                return mid;
            }

            if (arr[mid] < arr[mid + 1])
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        return left;
    }
}
