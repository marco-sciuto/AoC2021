bool firstLine = true;
var tableCount = 0;
int[] input = new int[1];
var bingoTables = new BingoTable[100];
for (var i = 0; i< 100; i++)
{
    bingoTables[i] = new BingoTable();
}

var lines = File.ReadLines("day4.txt");
foreach (var line in lines)
{
    if (firstLine)
    {
        input = line.Split(',').Select(n => int.Parse(n)).ToArray();
        firstLine = false;
        continue;
    }
    if (string.IsNullOrWhiteSpace(line))
    {
        continue;
    }
    bingoTables[tableCount/5].AddLine(line.Split(' ', options: StringSplitOptions.RemoveEmptyEntries));
    tableCount++;
}

foreach (var number in input)
{
    foreach (var bingoTable in bingoTables)
    {
        var winner = bingoTable.Extract(number);
        if (winner)
        {
            Console.WriteLine(bingoTable.UnextractedSum() * number);
        }
    }
}