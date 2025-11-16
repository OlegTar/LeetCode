/*
Given an array of strings strs, group the anagrams together. You can return the answer in any order.

 

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]

Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Explanation:

There is no string in strs that can be rearranged to form "bat".
The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
Example 2:

Input: strs = [""]

Output: [[""]]

Example 3:

Input: strs = ["a"]

Output: [["a"]]

 

Constraints:

1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
*/
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> result = new List<IList<string>>();

        var groups = strs.Select(s => {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            var sortedChars = new string(chars);
            return (s, sortedChars);
        }).ToList()
        .GroupBy(s => s.sortedChars)
        .Select(gr => gr.Select(g => g.s).ToList())
        .ToList();
        
        foreach (var gr in groups)
        {
            result.Add(gr);
        }

        return result;
    }
}
