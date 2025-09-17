namespace LeetCode75.Solutions
{
    [TestCase(12.75000, new int[] { 1, 12, -5, -6, 50, 3 }, 4)]
    [TestCase(4.0, new int[] { 0, 4, 0, 3, 2 }, 1)]
    [TestCase(5.00000, new int[] { 5 }, 1)]
    public class S000643 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.FindMaxAverage((int[])args[0], (int)args[1]);
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            if (k == 1) return nums.Max();

            int curSum = 0;
            int maxSum;

            for (int i = 0; i < k; i++)
            {
                curSum += nums[i];
            }

            maxSum = curSum;

            for (int i = k; i < nums.Length; i++)
            {
                curSum = curSum + nums[i] - nums[i - k];
                if (curSum > maxSum)
                {
                    maxSum = curSum;
                }
            }

            return (double)maxSum / k;
        }
    }
}