#region init
var text = File.ReadAllText("input").Split(Environment.NewLine);

int[,] matrix = new int[text[0].Length, text.Length];
Loop((i, j) =>
    {
        matrix[i, j] = int.Parse($"{text[i][j]}");
    });
#endregion

#region part1
var totalRisk=0;
Loop((i, j) =>
    {
        var localMin = 0;
        if(i-1 >= 0)
        {
            // check up
            if (matrix[i-1, j] > matrix[i,j])
            {
                localMin++;
            }
        }
        else
        {
            localMin++;
        }
        if(j-1 >= 0)
        {
            // check left
            if (matrix[i, j-1] > matrix[i,j])
            {
                localMin++;
            }
        }
        else
        {
            localMin++;
        }
        if(j+1 < text.First().Length)
        {
            // check right
            if (matrix[i, j+1] > matrix[i,j])
            {
                localMin++;
            }
        }
        else
        {
            localMin++;
        }
        if(i+1 < text.Length)
        {
            // check down
            if (matrix[i+1, j] > matrix[i,j])
            {
                localMin++;
            }
        }
        else
        {
            localMin++;
        }
        if (localMin == 4)
        {
            totalRisk += 1 + matrix[i,j];
        }
    });

Console.WriteLine($"Result part 1: {totalRisk}");
#endregion

#region part2
var regions = new List<int>();
Loop((i, j) =>
    {
        if (matrix[i,j] != 9)
        {
            regions.Add(ExploreRegion(i, j));
        }
    });

var part2 = 1;
foreach (var size in regions.OrderByDescending(x => x).Take(3))
{
    part2 *= size;
}
Console.WriteLine($"Result part 2: {part2}");
#endregion

#region functions
void Loop(Action<int, int> process)
{
    for (var i = 0; i < text!.Length; i++)
    {
        for (var j = 0; j < text[0].Length; j++)
        {
            process(i, j);
        }
    }
}

int ExploreRegion(int i, int j)
{
    var size = 1;
    matrix[i,j] = 9;
    if(i-1 >= 0)
    {
        // check up
        if (matrix[i-1, j] != 9)
        {
            size += ExploreRegion(i-1, j);
        }
    }
    if(j-1 >= 0)
    {
        // check left
        if (matrix[i, j-1] != 9)
        {
            size += ExploreRegion(i, j-1);
        }
    }
    if(j+1 < text.First().Length)
    {
        // check right
        if (matrix[i, j+1] != 9)
        {
            size += ExploreRegion(i, j+1);
        }
    }
    if(i+1 < text.Length)
    {
        // check down
        if (matrix[i+1, j] != 9)
        {
            size += ExploreRegion(i+1, j);
        }
    }
    return size;
}
#endregion