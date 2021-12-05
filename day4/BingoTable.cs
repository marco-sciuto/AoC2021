public class BingoTable
{
    private int[,] card;
    int[] rowSum, colSum;
    int lineCount;
    bool winner;

    public BingoTable()
    {
        card = new int[5,5];
        lineCount = 0;
        rowSum = new int[5];
        colSum = new int[5];
    }

    public void AddLine(string[] line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            card[lineCount, i] = int.Parse(line[i]);
        }
        lineCount++;
    }

    public bool Extract(int number)
    {
        if (winner)
        {
            return false;
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (card[i,j] == number)
                {
                    card[i,j] = -1;
                    rowSum[i]++;
                    colSum[j]++;
                    if (rowSum[i] == 5 || colSum[j] == 5)
                    {
                        winner = true;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int UnextractedSum()
    {
        int sum = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (card[i,j] != -1)
                {
                    sum += card[i,j];
                }
            }
        }
        return sum;
    }
}