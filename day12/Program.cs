var caves = new Dictionary<string, Cave>();
foreach(var tunnel in File.ReadLines("input"))
{
    var caveNames = tunnel.Split('-');
    var cave1 = CreateCave(caveNames[0]);
    var cave2 = CreateCave(caveNames[1]);
    ConnectCaves(cave1, cave2);
}

var exitPaths = 0;
VisitCave(caves["start"]);
var exitPathsPart1 = exitPaths;
Console.WriteLine($"Exit paths part 1: {exitPathsPart1}");

long exitPathsPart2 = exitPathsPart1;
foreach (var cave in caves.Values)
{
    if (cave.Name == "start" || cave.Name == "end" || cave.Name.ToUpper()[0].Equals(cave.Name[0]))
    {
        continue;
    }
    ResetCaves();
    exitPaths = 0;
    cave.allowedVisits = 2;
    VisitCave(caves["start"]);
    exitPathsPart2 += exitPaths - exitPathsPart1;
}
Console.WriteLine($"Exit paths part 2: {exitPathsPart2}");

void ResetCaves()
{
    foreach (var cave in caves.Values)
    {
        cave.Reset();
    }
}

void VisitCave(Cave cave)
{
    cave.IsVisited = true;
    if (cave.Name == "end")
    {
        exitPaths++;
    }
    foreach (var nextCave in cave.connectedCaves)
    {
        if (nextCave.Name.ToUpper()[0].Equals(nextCave.Name[0]) || (nextCave.Name.ToLower()[0].Equals(nextCave.Name[0]) && !nextCave.IsVisited))
        {
            VisitCave(nextCave);
        }
    }
    cave.IsVisited = false;
}

void ConnectCaves(Cave cave1, Cave cave2)
{
    cave1.ConnectTo(cave2);
    cave2.ConnectTo(cave1);
}

Cave CreateCave(string caveName)
{
    if (!caves.ContainsKey(caveName))
    {
        caves.Add(caveName, new Cave(caveName));
    }
    return caves[caveName];
}