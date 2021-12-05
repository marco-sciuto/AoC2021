public class Lines
{
    private List<Line> lines;
    private Line lastLine;
    private int maxX, maxY;
    private int[,]? field;
    
    public Lines()
    {
        lines = new List<Line>();
        lastLine = new Line();
    }
    public void AddPoint(int x, int y)
    {
        maxX = Math.Max(maxX, x);
        maxY = Math.Max(maxY, y);

        lastLine.AddPoint(x, y);
        if (lastLine.IsComplete())
        {
            lines.Add(lastLine);
            lastLine = new Line();
        }
    }

    public void Draw()
    {
        field = new int[maxX+1, maxY+1];
        Parallel.ForEach(lines, line =>
        {
            line.Draw(field);
        });
    }

    public int DangerPoints()
    {
        int count = 0;
        for (var x = 0; x < maxX; x++)
        {
            for (var y = 0; y < maxY; y++)
            {
                if(field![x,y] > 1)
                {
                    count++;
                }
            }
        }
        return count;
    }
}