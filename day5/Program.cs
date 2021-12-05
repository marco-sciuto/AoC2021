var Lines = new Lines();

foreach (var inputLine in File.ReadLines("puzzle"))
{
    var points = inputLine.Split(" -> ");
    foreach (var point in points)
    {
        var coordinates = point.Split(',');
        Lines.AddPoint(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
    }

}

Lines.Draw();

Console.WriteLine($"Danger points: {Lines.DangerPoints()}");
