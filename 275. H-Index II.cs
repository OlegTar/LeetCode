public class Solution {
    public int HIndex(int[] citations) {
        var left = 0;
        var right = citations.Length - 1;        
        var h = -1;
        
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var len = citations.Length - mid;
            
            if (citations[mid] == len)
            {
                h = citations[mid];
                break;
            }

            var currentH = Math.Min(citations[mid], len);
            h = Math.Max(h, currentH);

            if (citations[mid] > len)
            {
                right = mid - 1;
            }
            else 
            {
                left = mid + 1;
            }
        }

        return h;
    }
}
