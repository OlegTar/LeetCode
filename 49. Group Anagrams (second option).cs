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
strs[i] consists of lowercase English letters.
*/
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> result = new List<IList<string>>();

        var sortedStrings = new Dictionary<string, string>();
        foreach (var str in strs)
        {
            if (sortedStrings.ContainsKey(str)) 
            {
                continue;
            }

            var chars = str.ToCharArray();
            Array.Sort(chars);
            sortedStrings[str] = new string(chars);
        }

        Array.Sort(strs, Comparer<string>.Create((a, b) => {
            return sortedStrings[a].CompareTo(sortedStrings[b]);
        }));

        var group = new List<string>() { strs[0] };
        var lastSortedString = sortedStrings[strs[0]];
        for (var i = 1; i < strs.Length; i++)
        {
            var currentSortedString = sortedStrings[strs[i]];
            if (currentSortedString == lastSortedString)
            {
                group.Add(strs[i]);
            }
            else
            {
                lastSortedString = currentSortedString;
                result.Add(new List<string>(group));
                group.Clear();
                group.Add(strs[i]);
            }
        }

        if (group.Count > 0)
        {
            result.Add(group);
        }

        return result;
    }
}
