public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        var result = new int[spells.Length];
        
        for (var i = 0; i < spells.Length; i++)
        {
            var left = 0;
            var right = potions.Length - 1;
            var index = potions.Length;
            
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                long product = (long)spells[i] * (long)potions[mid];
                
                if (product >= success)
                {
                    right = mid - 1;
                    index = mid;
                }
                else 
                {
                    left = mid + 1;
                }
            }
            result[i] = potions.Length - index;
        }

        return result;
    }
}
