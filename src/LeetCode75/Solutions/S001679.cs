namespace LeetCode75.Solutions
{
    [TestCase(2, new int[] { 1, 2, 3, 4 }, 5)]
    [TestCase(1, new int[] { 3, 1, 3, 4, 3 }, 6)]
    public class S001679 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.MaxOperations((int[])args[0], (int)args[1]);
        }

        public int MaxOperations(int[] nums, int k)
        {
            int[] sortedNums = [.. nums.Order()];
            int left = 0;
            int right = sortedNums.Length - 1;
            int opCount = 0;

            while (left < right)
            {
                int curSum = sortedNums[left] + sortedNums[right];

                if (curSum == k)
                {
                    opCount++;
                    left++;
                    right--;
                }
                else if (curSum > k)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return opCount;
        }
    }
}