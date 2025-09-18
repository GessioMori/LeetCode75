namespace LeetCode75.Solutions;

[TestCase(1, new int[] { -5, 1, 5, 0, -7 })]
[TestCase(0, new int[] { -4, -3, -2, -1, 4, 3, 2 })]
public class S001732 : ISolution
{
    public object Run(params object[] args)
    {
        return this.LargestAltitude((int[])args[0]);
    }

    public int LargestAltitude(int[] gain)
    {
        int maxAltitude = 0;
        int currentAltitude = 0;

        for (int i = 0; i < gain.Length; i++)
        {
            currentAltitude += gain[i];
            maxAltitude = Math.Max(maxAltitude, currentAltitude);
        }

        return maxAltitude;
    }
}