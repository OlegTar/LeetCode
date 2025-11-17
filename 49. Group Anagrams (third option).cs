/*Given an array of strings strs, group the anagrams together. You can return the answer in any order.

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
strs[i] consists of lowercase English letters.*/

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        List<IList<string>> result = new List<IList<string>>();
        Dictionary<string, List<string>> groups = new();

        for (var i = 0; i < strs.Length; i++)
        {
            var chars = strs[i].ToCharArray();
            Array.Sort(chars);
            var group = new string(chars);
            if (!groups.ContainsKey(group))
            {
                groups[group] = new List<string>();
            }
            groups[group].Add(strs[i]);
        }

        result.AddRange(groups.Values);
        return result;
    }
}
