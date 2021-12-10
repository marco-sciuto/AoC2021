var openChars = new char[] { '(', '[', '{', '<' };
var closeChars = new char[] { ')', ']', '}', '>' };
var pointsPart1 = new int[] { 3, 57, 1197, 25137 };
var pointsPart2 = new int[] { 1, 2, 3, 4 };

var lineScores = new List<long>();
long part1 = 0;
foreach (var line in File.ReadLines("input"))
{
    var stack = new Stack<char>();
    var i = 0;
    var corruptedLine = false;
    for (; i < line.Length; i++)
    {
        var c = line[i];
        if(openChars.Contains(c))
        {
            stack.Push(c);
        }
        else
        {
            var stackChar = stack.Pop();
            var closeCharIndex = Array.IndexOf(closeChars, c);
            if (Array.IndexOf(openChars, stackChar) != closeCharIndex)
            {
                part1 += pointsPart1[closeCharIndex];
                corruptedLine = true;
                break;
            }
        }
    }
    if (!corruptedLine)
    {
        long lineScore = 0;
        while (stack.Count > 0)
        {
            var stackChar = stack.Pop();
            lineScore = lineScore * 5 + pointsPart2[Array.IndexOf(openChars, stackChar)];
        }
        lineScores.Add(lineScore);
    }
}

lineScores.Sort();
var part2 = lineScores.ElementAt(lineScores.Count / 2);
Console.WriteLine($"Part1: {part1}");
Console.WriteLine($"Part2: {part2}");