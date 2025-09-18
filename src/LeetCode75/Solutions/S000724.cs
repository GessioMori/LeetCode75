namespace LeetCode75.Solutions;

[TestCase(3, new int[] { 1, 7, 3, 6, 5, 6 })]
[TestCase(-1, new int[] { 1, 2, 3 })]
[TestCase(0, new int[] { 2, 1, -1 })]
public class S000724 : ISolution
{
    public object Run(params object[] args)
    {
        return this.PivotIndex((int[])args[0]);
    }

    public int PivotIndex(int[] nums)
    {
        int leftSum = 0;
        int rightSum = nums.Sum() - nums[0];

        if (leftSum == rightSum) return 0;

        for (int i = 1; i < nums.Length; i++)
        {
            leftSum += nums[i - 1];
            rightSum -= nums[i];

            if (leftSum == rightSum) return i;
        }

        return -1;
    }
}