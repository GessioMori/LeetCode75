namespace LeetCode75.Solutions
{
    [TestCase(6, new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2)]
    [TestCase(10, new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3)]
    [TestCase(4, new int[] { 0, 0, 0, 1 }, 4)]
    public class S001004 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.LongestOnes((int[])args[0], (int)args[1]);
        }

        public int LongestOnes(int[] nums, int k)
        {
            int maxOnesLength = 0;
            int currZerosFliped = 0;

            int i = 0;
            int j = 0;

            while (j < nums.Length)
            {
                if (nums[j] == 1)
                {
                    j++;
                }
                else if (currZerosFliped < k)
                {
                    currZerosFliped++;
                    j++;
                }
                else
                {
                    if (nums[i] == 0)
                    {
                        currZerosFliped--;
                    }

                    i++;
                }

                maxOnesLength = Math.Max(maxOnesLength, j - i);
            }

            return maxOnesLength;
        }
    }
}