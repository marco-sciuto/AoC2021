var displaySegmnents = new int[9];
foreach(var line in File.ReadLines("input"))
{
    var digits = line.Split(" | ").Last().Split(' ');
    foreach (var digit in digits)
    {
        displaySegmnents[digit.Length]++;
    }
}

Console.WriteLine($"Result for part 1: {displaySegmnents[2] + displaySegmnents[3] + displaySegmnents[4] + displaySegmnents[7]}");

long total = 0;
foreach(var line in File.ReadLines("input"))
{
    var displayDigits = new string[10];
    var signals = line.Split(" | ").First().Split(' ').ToList();
    do
    {
        var toRemove = new List<string>();
        foreach (var signal in signals)
        {
            if (signal.Length == 2 && displayDigits[1] == null)
            {
                SaveDigit(displayDigits, 1, signal, toRemove);
            }
            else if (signal.Length == 4 && displayDigits[4] == null)
            {
                SaveDigit(displayDigits, 4, signal, toRemove);
            }
            else if (signal.Length == 3 && displayDigits[7] == null)
            {
                SaveDigit(displayDigits, 7, signal, toRemove);
            }
            else if (signal.Length == 7 && displayDigits[8] == null)
            {
                SaveDigit(displayDigits, 8, signal, toRemove);
            }
            else if (signal.Length == 6)
            {
                if (displayDigits[9] == null && displayDigits[3] != null && signal.Include(displayDigits[3]))
                {
                    SaveDigit(displayDigits, 9, signal, toRemove);
                }
                else if (displayDigits[0] == null && displayDigits[9] != null && displayDigits[7] != null && signal.Include(displayDigits[7]))
                {
                    SaveDigit(displayDigits, 0, signal, toRemove);
                }
                else if (displayDigits[6] == null && displayDigits[0] != null && displayDigits[9] != null)
                {
                    SaveDigit(displayDigits, 6, signal, toRemove);
                }
            }
            else if (signal.Length == 5)
            {
                if (displayDigits[3] == null && displayDigits[1] != null && signal.Include(displayDigits[1]))
                {
                    SaveDigit(displayDigits, 3, signal, toRemove);
                }
                else if (displayDigits[5] == null && displayDigits[6] != null && displayDigits[6].Include(signal))
                {
                    SaveDigit(displayDigits, 5, signal, toRemove);
                }
                else if (displayDigits[2] == null && displayDigits[3] != null && displayDigits[5] != null)
                {
                    SaveDigit(displayDigits, 2, signal, toRemove);
                }
            }
        }
        foreach(var item in toRemove)
            signals.Remove(item);
    } while(displayDigits.Any(d => d == null));

    var sum = 0;
    foreach (var digit in line.Split(" | ").Last().Split(' '))
    {
        var value = Array.IndexOf(displayDigits, digit.SortString());
        sum = sum*10 + value;
    }
    total += sum;
}

void SaveDigit(string[] displayDigits, int index, string signal, List<string> toRemove)
{
    displayDigits[index] = signal.SortString();
    toRemove.Add(signal);
}

Console.WriteLine($"Result for part 2: {total}");