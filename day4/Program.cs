// See https://aka.ms/new-console-template for more information

var count = -1;
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
    count++;
    if (count == 0)
    {
        input = line.Split(',').Select(n => int.Parse(n)).ToArray();
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