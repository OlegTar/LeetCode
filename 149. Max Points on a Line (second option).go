/*Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.

 

Example 1:


Input: points = [[1,1],[2,2],[3,3]]
Output: 3
Example 2:


Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
Output: 4
 

Constraints:

1 <= points.length <= 300
points[i].length == 2
-104 <= xi, yi <= 104
All the points are unique.*/
type Line struct{
    k float64
    m float64
    isVertical bool
    x int
}

var eps float64 = 0.000001

func maxPoints(points [][]int) int {
    lines := []Line{}
    for i := 0; i < len(points); i++ {
        for j := i + 1; j < len(points); j++ {
            line := makeLineFromPoints(points[i], points[j])
            lines = append(lines, line)
        }
    }

    result := 1
    for _, line := range(lines) {
        countPoints := 0
        for _, point := range(points) {
            if (isPointOnLine(line, point)) {
                countPoints++
            }
        }
        result = max(result, countPoints)
    }
    return result;
}

func makeLineFromPoints(point1 []int, point2 []int) Line {
    //(x - x1)/(x2 - x1) = (y - y1) / (y2 - y1)

    xDenominator := point2[0] - point1[0];//x2 - x1
    yDenominator := point2[1] - point1[1];//y2 - y1

    if (xDenominator == 0) {
        return Line{
            isVertical: true,
            x: point1[0],
        }
    }

    //(y - y1)/ yDenominator  = (x - x1) / xDenominator
    //y - y1 = ((x - x1) / xDenominator) * yDenominator
    //y - y1 = x * yDenominator/xDenominator - x1 * yDenominator / xDenominator
    //yDenominator/xDenominator = k
    //y - y1 = x * k - x1 * k
    //y = x * k - x1 * k + y1
    //y = x * k + (y1 - x1 * k)
    //y = x * k + m
    //m = y1 - x1 * k

    // fmt.Printf("yDenominator = %f", yDenominator)
    // fmt.Printf("yDenominator = %f", yDenominator)

    k := float64(yDenominator)/float64(xDenominator);

    return Line{
        k: k,
        m: float64(point1[1]) - float64(point1[0]) * k,
    }
}

func isPointOnLine(line Line, point []int) bool {
    if (line.isVertical) {
        return point[0] == line.x
    }

    x, y := point[0], point[1]
    result := line.k * float64(x) + line.m - float64(y)
    return abs(result) < eps;
}

func abs(x float64) float64 {
    if (x < 0) {
        return -x;
    }
    return x;
}
