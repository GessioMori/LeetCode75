namespace LeetCode75.Solutions
{
    [TestCase(49, new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 })]
    [TestCase(1, new int[] { 1, 1 })]
    public class S000011 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.MaxArea((int[])args[0]);
        }

        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int currentArea = 0;

            while (i < j)
            {
                int calculatedArea = (j - i) * int.Min(height[i], height[j]);

                if (calculatedArea > currentArea)
                {
                    currentArea = calculatedArea;
                }

                if (height[i] < height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return currentArea;
        }
    }
}