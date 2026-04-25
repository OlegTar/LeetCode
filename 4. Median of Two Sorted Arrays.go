/*Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

 

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106*/
func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
	n := len(nums1) + len(nums2)
	if n%2 == 0 {
		mid1 := solve(nums1, nums2, n/2-1, 0, len(nums1)-1, 0, len(nums2)-1)
		mid2 := solve(nums1, nums2, n/2, 0, len(nums1)-1, 0, len(nums2)-1)
		return float64(mid1+mid2) / 2
	}
	return solve(nums1, nums2, n/2, 0, len(nums1)-1, 0, len(nums2)-1)
}

func solve(a, b []int, k, aStart, aEnd, bStart, bEnd int) float64 {
	if aStart > aEnd {
		return float64(b[k-aStart])
	}

	if bStart > bEnd {
		return float64(a[k-bStart])
	}

	midA := (aStart + aEnd) / 2
	midB := (bStart + bEnd) / 2

	if k > midA + midB {
		if a[midA] < b[midB] {
			return solve(a, b, k, midA+1, aEnd, bStart, bEnd)
		} else {
			return solve(a, b, k, aStart, aEnd, midB+1, bEnd)
		}
	} else {
		if a[midA] < b[midB] {
			return solve(a, b, k, aStart, aEnd, bStart, midB-1)
		} else {
			return solve(a, b, k, aStart, midA-1, bStart, bEnd)
		}
	}
}
