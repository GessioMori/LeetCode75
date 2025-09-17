namespace LeetCode75.Solutions
{
    [TestCase(true, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(false, new int[] { 5, 4, 3, 2, 1 })]
    [TestCase(true, new int[] { 2, 1, 5, 0, 4, 6 })]
    [TestCase(true, new int[] { 7, 6, 1, 9, 3, 2, 4 })]
    public class S000334 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.IncreasingTriplet((int[])args[0]);
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;

            int firstCandidate = nums[0];
            int secondCandidate = int.MaxValue;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > secondCandidate) return true;

                if (nums[i] > firstCandidate && nums[i] < secondCandidate)
                {
                    secondCandidate = nums[i];
                }
                else if (nums[i] < firstCandidate)
                {
                    firstCandidate = nums[i];
                }
            }

            return false;
        }
    }
}