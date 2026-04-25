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
readonly struct Line
{
    public double K { get; }
    public double M { get; }
    public bool IsVertical { get; }
    public int X { get; }

    public Line(double k, double m, bool isVertical, int x)
    {
        K = k;
        M = m;
        IsVertical = isVertical;
        X = x;
    }
}

public class Solution
{
    private const double Eps = 0.000001;

    public int MaxPoints(int[][] points)
    {
        var lines = new List<Line>();

        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                var line = MakeLineFromPoints(points[i], points[j]);
                lines.Add(line);
            }
        }

        int result = 1;
        foreach (var line in lines)
        {
            int countPoints = 0;
            foreach (var point in points)
            {
                if (IsPointOnLine(line, point))
                {
                    countPoints++;
                }
            }
            result = Math.Max(result, countPoints);
        }
        return result;
    }

    private Line MakeLineFromPoints(int[] point1, int[] point2)
    {
        // (x - x1)/(x2 - x1) = (y - y1) / (y2 - y1)

        int xDenominator = point2[0] - point1[0]; // x2 - x1
        int yDenominator = point2[1] - point1[1]; // y2 - y1

        if (xDenominator == 0)
        {
            return new Line(0, 0, true, point1[0]);
        }

        // y = x * k + m
        // k = yDenominator / xDenominator
        // m = y1 - x1 * k

        double k = (double)yDenominator / xDenominator;
        double m = point1[1] - point1[0] * k;

        return new Line(k, m, false, 0);
    }

    private bool IsPointOnLine(Line line, int[] point)
    {
        if (line.IsVertical)
        {
            return point[0] == line.X;
        }

        int x = point[0], y = point[1];
        double result = line.K * x + line.M - y;
        return Math.Abs(result) < Eps;
    }
}
