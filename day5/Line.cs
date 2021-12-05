public class Line
{
    List<int> points;
    bool completed;

    public Line()
    {
        points = new List<int>(4);
    }

    public void AddPoint(int x, int y)
    {
        points.Add(x);
        points.Add(y);
        if (points.Count == 4)
        {
            completed = true;
        }
    }

    public bool IsComplete()
    {
        return completed;
    }

    public void Draw(int[,] field)
    {
        if (IsHorizontalOrVertical())
        {
            Loop((x, y) => field[x,y]++ );
        }
        else
        {
            Loop((x, y) => {
                if (IsToDraw(x, y))
                {
                    field[x,y]++;
                }
            });
        }
    }

    public bool IsHorizontalOrVertical()
    {
        return (points[0] == points[2]) || (points[1] == points[3]);
    }

    private void Loop(Action<int, int> perform)
    {
        var maxX = Math.Max(points[0], points[2]);
        var maxY = Math.Max(points[1], points[3]);
        for (var x = Math.Min(points[0], points[2]); x <= maxX; x++)
        {
            for (var y = Math.Min(points[1], points[3]); y <= maxY; y++)
            {
                perform(x, y);
            }
        }
    }

    private bool IsToDraw(int x, int y)
    {
        var transposed = new int[] { points[0], points[1] };
        int minX = Math.Min(points[0], points[2]);
        int minY = Math.Min(points[1], points[3]);
        transposed[0] -= minX;
        transposed[1] -= minY;
        var size = Math.Max(transposed[0], transposed[1]);
        if ((transposed[0] == 0 && transposed[1] == 0) || (transposed[0] == size && transposed[1] == size))
        {
            return x-minX == y-minY;
        }
        else
        {
            return x-minX + y-minY == size;
        }
    }
}