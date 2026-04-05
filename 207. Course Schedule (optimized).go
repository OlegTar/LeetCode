/*
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.
Example 2:

Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.
 

Constraints:

1 <= numCourses <= 2000
0 <= prerequisites.length <= 5000
prerequisites[i].length == 2
0 <= ai, bi < numCourses
All the pairs prerequisites[i] are unique.
*/
func canFinish(numCourses int, prerequisites [][]int) bool {
	edges := map[int][]int{}
	edgesTo := make([]int, numCourses)

	for _, edge := range prerequisites {
		if _, ok := edges[edge[1]]; !ok {
			edges[edge[1]] = []int{}
		}
		edges[edge[1]] = append(edges[edge[1]], edge[0])
		edgesTo[edge[0]]++
	}

	queue := []int{}
	for v, count := range edgesTo {
		if count == 0 {
			queue = append(queue, v)
		}
	}

    count := 0

	for len(queue) > 0 {
		v := queue[0]
		queue = queue[1:]
        count++
        for _, neighbor := range edges[v] {
            edgesTo[neighbor]--
            if edgesTo[neighbor] == 0 {
                queue = append(queue, neighbor)
            }
        }
	}

	return count == numCourses;
}
