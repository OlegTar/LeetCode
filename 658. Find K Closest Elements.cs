public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var left = 0;
        var right = arr.Length - 1;        
        var last = right;
        var index = right;              
        var minDiff = Math.Abs(arr[last] - x);
      
        while (left <= right)
        {
            var mid = left + (right - left) / 2;            
            var diff = arr[mid] - x;
            var absDiff = Math.Abs(diff);

            if ((absDiff < minDiff) || ((absDiff == minDiff) && arr[mid] < arr[last])) 
            {
                minDiff = absDiff;
                index = mid;
                last = index;
            }

            if (diff == 0)
            {
                break;
            }
            else if (diff < 0)
            {
                left = mid + 1;                
            }
            else 
            {
                right = mid - 1;
            }
        }
        
        var result = new int[k * 2 - 1];
        result[k - 1] = arr[index];

        var n = k - 1;
        var leftBound = k - 1;
        var radiusLeft = 1;
        var radiusRight = 1;
        for (var i = 0; i < n; i++)
        {
            var leftIndex = index - radiusLeft;
            var rightIndex = index + radiusRight;
            
            var leftEl = int.MaxValue;
            if (leftIndex >= 0)
            {
                leftEl = arr[leftIndex];
            }
            
            var rightEl = int.MaxValue;
            if (rightIndex <= arr.Length - 1)
            {
                rightEl = arr[rightIndex];
            }

            if (leftEl != int.MaxValue && right != int.MaxValue && Math.Abs(leftEl - x) <= Math.Abs(rightEl - x))
            {
                result[k - 1 - radiusLeft] = leftEl;
                leftBound = k - 1 - radiusLeft;
                radiusLeft++;
            }
            else {
                result[k - 1 + radiusRight] = rightEl;
                radiusRight++;
            }
        }
        return result[leftBound..(leftBound + k)];
    }
}
