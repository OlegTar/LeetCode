public class Solution {
    public int FindKthPositive(int[] arr, int k) 
    {
        if (k < arr[0])
        {
            return k;
        }
        
        var countNumbersBeforeFirst = arr[0] - 1;
        k -= countNumbersBeforeFirst;

        var missingInArr = CountOfMissingIntegers(arr[0], arr[^1], arr.Length);
        if (missingInArr < k)
        {
            k -= missingInArr;
            return arr[^1] + k;
        }

        var left = 0;
        var right = arr.Length - 1;

        while (left + 1 < right)
        {
            var mid = left + (right - left) / 2;
            var missing = CountOfMissingIntegers(arr[left], arr[mid], mid - left + 1);   
            
            if (missing < k)
            {
                k -= missing;
                left = mid;
            }
            else 
            {
                right = mid;
            }
        }
        return arr[left] + k;
    }

    public int CountOfMissingIntegers(int start, int endFact, int length)
    {
        var endWhichMustBe = start + length - 1;
        return endFact - endWhichMustBe;
    }
}
