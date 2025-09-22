namespace LeetCode75.Solutions;

[TestCase(1, [new int[] { 3, 2, 1 }, new int[] { 1, 7, 6 }, new int[] { 2, 7, 7 }])]
[TestCase(3, [new int[] { 3, 1, 2, 2 }, new int[] { 1, 4, 4, 5 }, new int[] { 2, 4, 2, 2 }, new int[] { 2, 4, 2, 2 }])]
public class S002352 : ISolution
{
    public object Run(params object[] args)
    {
        return this.EqualPairs([.. args.Cast<int[]>()]);
    }

    public int EqualPairs(int[][] grid)
    {
        int equalCount = 0;
        bool isEqual = true;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                isEqual = true;

                for (int k = 0; k < grid.Length; k++)
                {
                    if (grid[i][k] != grid[k][j])
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    equalCount++;
                }
            }

        }

        return equalCount;
    }
}