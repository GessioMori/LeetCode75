namespace LeetCode75.Solutions
{
    [TestCase(new bool[] { true, true, true, false, true }, new int[] { 2, 3, 5, 1, 3 }, 3)]
    [TestCase(new bool[] { true, false, false, false, false }, new int[] { 4, 2, 1, 1, 2 }, 1)]
    public class S001431 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.KidsWithCandies((int[])args[0], (int)args[1]);
        }

        private IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandies = candies.Max(x => x);

            return [.. candies.Select(x => x + extraCandies >= maxCandies)];
        }
    }
}