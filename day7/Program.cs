var input = File.ReadAllText("input").Split(',').Select(n => int.Parse(n));
var crabs = new int[input.Max()+1];
foreach (var crab in input)
{
    crabs[crab]++;
}

long minFuelPart1 = long.MaxValue;
long minFuelPart2 = long.MaxValue;
for (var i = 0; i < crabs.Length; i++)
{
    long totalFuelPart1 = 0;
    long totalFuelPart2 = 0;
    for (var j = 0; j < crabs.Length; j++)
    {
        var distance = Math.Abs(i-j);
        totalFuelPart1 += distance * crabs[j];
        totalFuelPart2 += distance * (distance + 1) * crabs[j] / 2;
    }
    minFuelPart1 = Math.Min(minFuelPart1, totalFuelPart1);
    minFuelPart2 = Math.Min(minFuelPart2, totalFuelPart2);
}

Console.WriteLine($"Minimum fuel required for part 1: {minFuelPart1}");
Console.WriteLine($"Minimum fuel required for part 2: {minFuelPart2}");