namespace LeetCode75.Solutions
{
    [TestCase(new int[] { 1, 3, 12, 0, 0 }, new int[] { 0, 1, 0, 3, 12 })]
    [TestCase(new int[] { 0 }, new int[] { 0 })]
    public class S000283 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.MoveZeroes((int[])args[0]);
        }

        public int[] MoveZeroes(int[] nums)
        {
            int zeroCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    nums[i - zeroCount] = nums[i];
                }
            }

            for (int i = nums.Length - 1; zeroCount > 0; zeroCount--, i--)
            {
                nums[i] = 0;
            }

            return nums;
        }
    }
}