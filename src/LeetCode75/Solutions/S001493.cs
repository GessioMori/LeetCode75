namespace LeetCode75.Solutions;

[TestCase(3, new int[] { 1, 1, 0, 1 })]
[TestCase(5, new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 })]
[TestCase(2, new int[] { 1, 1, 1 })]
[TestCase(4, new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1 })]
public class S001493 : ISolution
{
    public object Run(params object[] args)
    {
        return this.LongestSubarray((int[])args[0]);
    }

    public int LongestSubarray(int[] nums)
    {
        int i = 0;
        int j = 0;
        bool hasZeroInSequence = false;
        int maxOnesSequence = 0;
        bool hasZero = nums.Any(x => x == 0);

        while (j < nums.Length)
        {
            if (nums[j] == 1)
            {
                j++;
            }
            else if (!hasZeroInSequence)
            {
                j++;
                hasZeroInSequence = true;
            }
            else
            {
                if (nums[i] == 0)
                {
                    hasZeroInSequence = false;
                }

                i++;
            }

            maxOnesSequence = Math.Max(maxOnesSequence, j - i - (hasZeroInSequence ? 1 : 0));
        }

        return maxOnesSequence - (hasZero ? 0 : 1);
    }
}