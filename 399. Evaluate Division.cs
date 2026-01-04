/*You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.

Return the answers to all queries. If a single answer cannot be determined, return -1.0.

Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.

Note: The variables that do not occur in the list of equations are undefined, so the answer cannot be determined for them.

 

Example 1:

Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
Explanation: 
Given: a / b = 2.0, b / c = 3.0
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? 
return: [6.0, 0.5, -1.0, 1.0, -1.0 ]
note: x is undefined => -1.0
Example 2:

Input: equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0], queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
Output: [3.75000,0.40000,5.00000,0.20000]
Example 3:

Input: equations = [["a","b"]], values = [0.5], queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
Output: [0.50000,2.00000,-1.00000,-1.00000]
 

Constraints:

1 <= equations.length <= 20
equations[i].length == 2
1 <= Ai.length, Bi.length <= 5
values.length == equations.length
0.0 < values[i] <= 20.0
1 <= queries.length <= 20
queries[i].length == 2
1 <= Cj.length, Dj.length <= 5
Ai, Bi, Cj, Dj consist of lower case English letters and digits.*/
public class Solution {
    private Dictionary<string, Dictionary<string, double>> dict = new();

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        for (var i = 0; i < equations.Count; i++)
        {
            var var1 = equations[i][0];
            var var2 = equations[i][1];

            if (!dict.ContainsKey(var1))
            {
                dict[var1] = new Dictionary<string, double>();
            }
            
            dict[var1][var2] = values[i];
            dict[var1][var1] = 1.0;
            
            if (!dict.ContainsKey(var2))
            {
                dict[var2] = new Dictionary<string, double>();
            }

            dict[var2][var1] = 1 / values[i];
            dict[var2][var2] = 1.0;
        }

        var answer = new double[queries.Count];

        var j = 0;
        foreach (var query in queries)
        {
            var var1 = query[0];
            var var2 = query[1];

            if (!dict.ContainsKey(var1) || !dict.ContainsKey(var2))
            {
                answer[j++] = -1.0;
                continue;
            }

            var combination = new List<double>();
            var seen = new HashSet<string>();
            seen.Add(var1);
            answer[j++] = dfs(dict[var1], var2, combination, seen);
        }

        return answer;
    }

    public double dfs(Dictionary<string, double> dct, string targetVar, List<double> combination,
        HashSet<string> seen)
    {
        var result = -1.0;
        if (dct.ContainsKey(targetVar))
        {
            combination.Add(dct[targetVar]);
            result = 1.0;
            for (var i = 0; i < combination.Count; i++)
            {
                result *= combination[i];
            }
            return result;
        }

        foreach (var @var in dct.Keys)
        {
            if (seen.Contains(@var)) continue;
            seen.Add(@var);
            combination.Add(dct[@var]);
            result = dfs(dict[@var], targetVar, combination, seen);
            if (result != -1.0) break;
            combination.RemoveAt(combination.Count - 1);
            seen.Remove(@var);
        }
        return result;
    }
}
