public class Cave
{
    private int currentVisits;
    public int allowedVisits;
    public string Name { get; private set; }
    public bool IsVisited {
        get
        {
            return allowedVisits == currentVisits;
        }
        set
        {
            if (value)
            {
                currentVisits++;
            }
            else
            {
                currentVisits--;
            }
        }
    }

    public List<Cave> connectedCaves { get; set; }
    public Cave(string name)
    {
        allowedVisits = 1;
        Name = name;
        connectedCaves = new List<Cave>();
    }

    public void ConnectTo(Cave other)
    {
        if (!connectedCaves.Contains(other))
        {
            connectedCaves.Add(other);
        }
    }

    public void Reset()
    {
        allowedVisits = 1;
        currentVisits = 0;
    }
}