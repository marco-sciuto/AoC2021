var lanternfishes = new long[9];
var input = File.ReadAllText("puzzle").Split(',').Select(n => int.Parse(n));
foreach (var timer in input)
{
    lanternfishes[timer]++;
}

for (var day = 0; day < 256; day++)
{
    var newFishes = lanternfishes[0];
    for (int i = 1; i < lanternfishes.Length; i++)
    {
        lanternfishes[i-1] = lanternfishes[i];
    }
    lanternfishes[6] += newFishes;
    lanternfishes[8] = newFishes;
}

Console.WriteLine($"Fishes: {lanternfishes.Sum()}");