namespace LeetCode75.Solutions
{
    [TestCase(new int[] { 24, 12, 8, 6 }, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 0, 0, 9, 0, 0 }, new int[] { -1, 1, 0, -3, 3 })]
    public class S000238 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.ProductExceptSelf((int[])args[0]);
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] ints = new int[nums.Length];

            int carrier = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                ints[i] = carrier;
                carrier *= nums[i];
            }

            carrier = 1;

            for (int i = ints.Length - 1; i >= 0; i--)
            {
                ints[i] *= carrier;
                carrier *= nums[i];
            }

            return ints;
        }
    }
}