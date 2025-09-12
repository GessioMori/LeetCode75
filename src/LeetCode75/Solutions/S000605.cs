namespace LeetCode75.Solutions
{
    [TestCase(true, new int[] { 1, 0, 0, 0, 1 }, 1)]
    [TestCase(false, new int[] { 1, 0, 0, 0, 1 }, 2)]
    public class S000605 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.CanPlaceFlowers((int[])args[0], (int)args[1]);
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int flowersLeft = n;

            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowersLeft == 0) return true;

                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    flowersLeft--;
                }
            }

            return flowersLeft == 0;
        }
    }
}