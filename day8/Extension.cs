public static class Extension
{
    public static bool Include(this string str, string other)
    {
        foreach (var letter in other)
        {
            if (!str.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }

    public static string SortString(this string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }
}
