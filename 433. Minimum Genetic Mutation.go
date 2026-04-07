/*
A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.

Suppose we need to investigate a mutation from a gene string startGene to a gene string endGene where one mutation is defined as one single character changed in the gene string.

For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
There is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it a valid gene string.

Given the two gene strings startGene and endGene and the gene bank bank, return the minimum number of mutations needed to mutate from startGene to endGene. If there is no such a mutation, return -1.

Note that the starting point is assumed to be valid, so it might not be included in the bank.

 

Example 1:

Input: startGene = "AACCGGTT", endGene = "AACCGGTA", bank = ["AACCGGTA"]
Output: 1
Example 2:

Input: startGene = "AACCGGTT", endGene = "AAACGGTA", bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
Output: 2
 

Constraints:

0 <= bank.length <= 10
startGene.length == endGene.length == bank[i].length == 8
startGene, endGene, and bank[i] consist of only the characters ['A', 'C', 'G', 'T'].
*/
func minMutation(startGene string, endGene string, bank []string) int {
    graph := map[string][]string{}
    for _, gene := range(bank) {
        graph[gene] = []string{}
    }
    graph[startGene] = []string{}

    if _, ok := graph[endGene]; !ok {
        return -1;
    }

    for gene, _ := range(graph) {
        for i := 0; i < len(bank); i++ {
            if (isEdge(gene, bank[i])) {
                graph[gene] = append(graph[gene], bank[i])
            } 
        }
    }

    visited := map[string]struct{}{}
    queue := []string{ startGene }
    mutations := 0
    for len(queue) > 0 {
        size := len(queue)
        mutations++
        for i := 0; i < size; i++ {
            gene := queue[0]
            queue = queue[1:]

            neighbors := graph[gene];
            for _, neighbor := range(neighbors) {
                if (neighbor == endGene) {
                    return mutations
                }

                if _, ok := visited[neighbor]; !ok {
                    visited[neighbor] = struct{}{}
                    queue = append(queue, neighbor)
                }
            }
        }
    }

    return -1;
}

func isEdge(gene1 string, gene2 string) bool {
    countDiffs := 0
    for i := 0; i < len(gene1); i++ {
        if gene1[i] != gene2[i] {
            countDiffs++;
            if (countDiffs >= 2) {
                return false;
            }
        }
    }

    return countDiffs == 1;
}
