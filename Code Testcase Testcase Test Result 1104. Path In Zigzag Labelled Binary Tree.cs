/*In an infinite binary tree where every node has two children, the nodes are labelled in row order.

In the odd numbered rows (ie., the first, third, fifth,...), the labelling is left to right, while in the even numbered rows (second, fourth, sixth,...), the labelling is right to left.



Given the label of a node in this tree, return the labels in the path from the root of the tree to the node with that label.

 

Example 1:

Input: label = 14
Output: [1,3,4,14]
Example 2:

Input: label = 26
Output: [1,2,6,10,26]
 

Constraints:

1 <= label <= 10^6*/
public class Solution {
    public IList<int> PathInZigZagTree(int label) {
        var list = new List<int>();
        var pow = 1;
        while (label >= pow)
        {
            pow *= 2;
        }
        
        var change = false;
        while (label >= 1)
        {
            var temp = label;
            if (change) 
            {
                var delta = pow - 1 - label;
                temp = (pow / 2) + delta;
            }
            pow /= 2;
            change = !change;
            list.Add(temp);
            label /= 2;
        }

        list.Reverse();
        return list;
    }
}
