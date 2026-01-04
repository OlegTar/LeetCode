/*
You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

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
Ai, Bi, Cj, Dj consist of lower case English letters and digits.
*/
class Solution {
    Map<String, HashMap<String, Double>> dict = new HashMap<String, HashMap<String, Double>>();
    public double[] calcEquation(List<List<String>> equations, double[] values, List<List<String>> queries) {
        for (int i = 0; i < equations.size(); i++) {
            String var1 = equations.get(i).get(0);
            String var2 = equations.get(i).get(1);

            if (!dict.containsKey(var1)) {
                dict.put(var1, new HashMap<String, Double>());
            }
            dict.get(var1).put(var2, values[i]);

            if (!dict.containsKey(var2)) {
                dict.put(var2, new HashMap<String, Double>());
            }
            dict.get(var2).put(var1, 1 / values[i]);
            dict.get(var1).put(var1, 1.0);
            dict.get(var2).put(var2, 1.0);
        }

        double[] answer = new double[queries.size()];
        int j = 0;
        for (List<String> query : queries) {
            String var1 = query.get(0);
            String var2 = query.get(1);

            if (!dict.containsKey(var1) || !dict.containsKey(var2)) {
                answer[j++] = -1.0;
                continue;
            }

            List<Double> combination = new ArrayList<>();
            Set<String> seen = new HashSet<>();
            seen.add(var1);
            answer[j++] = dfs(dict.get(var1), var2, combination, seen);
        }

        return answer;
    }

    public double dfs(Map<String, Double> dct, String targetVar, List<Double> combination, Set<String> seen) {
        double result = -1.0;
        if (dct.containsKey(targetVar)) {
            combination.add(dct.get(targetVar));
            result = 1.0;
            for (int i = 0; i < combination.size(); i++) {
                result *= combination.get(i);
            }
            return result;
        }

        for (String key : dct.keySet()) {
            if (seen.contains(key)) continue;
            seen.add(key);
            combination.add(dct.get(key));
            result = dfs(dict.get(key), targetVar, combination, seen);
            if (result != -1.0) break;
            combination.remove(combination.size() - 1);
            seen.remove(key);
        }
        return result;
    }
}
