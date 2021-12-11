var octopuses = new int[10,10];
var totalFlashes = 0;
int day = 0;
var i = 0;

foreach(var line in File.ReadLines("input"))
{
    for(var j = 0; j < line.Length; j++)
    {
        octopuses[i,j] = line[j] - '0';
    }
    i++;
}

for (; day < 100; day++)
{
    AdvanceDay();
}

Console.WriteLine($"Total flashes in 100 days: {totalFlashes}");

totalFlashes = 0;
while (totalFlashes < 100)
{
    totalFlashes = 0;
    AdvanceDay();
    day++;
}

Console.WriteLine($"Cavern illuminated in {day} days");

void AdvanceDay()
{
    var flashingOctopuses = new List<(int, int)>();
    for (i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (octopuses[i,j] == 10)
            {
                octopuses[i,j] = 0;
            }
            octopuses[i,j]++;
            if (octopuses[i,j] == 10)
            {
                flashingOctopuses.Add((i, j));
            }
        }
    }

    MakeThemFlash(flashingOctopuses);
}

void MakeThemFlash(List<(int, int)> flashingOctopuses)
{
    var chargedOctopuses = new List<(int, int)>();
    foreach (var octopus in flashingOctopuses)
    {
        totalFlashes++;
        var charged = chargeNearby(octopus);
        if (charged.Count != 0)
        {
            chargedOctopuses.AddRange(charged);
        }
    }
    if (chargedOctopuses.Count > 0)
    {
        MakeThemFlash(chargedOctopuses);
    }
}

List<(int, int)> chargeNearby((int, int) octopus)
{
    var chargedOctopuses = new List<(int, int)>();
    for (int i = octopus.Item1 - 1; i <= octopus.Item1 + 1; i++)
    {
        if (i < 0 || i > 9)
        {
            continue;
        }
        for (int j = octopus.Item2 - 1 ; j <= octopus.Item2 + 1; j++)
        {
            if (j < 0 || j > 9 || (i == octopus.Item1 && j == octopus.Item2))
            {
                continue;
            }
            if (octopuses[i,j] != 10)
            {
                octopuses[i,j]++;
                if (octopuses[i,j] == 10)
                {
                    chargedOctopuses.Add((i,j));
                }
            }
        }
    }
    return chargedOctopuses;
}