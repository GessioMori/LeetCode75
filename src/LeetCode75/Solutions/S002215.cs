namespace LeetCode75.Solutions;

[TestCase(new int[] { }, new int[] { })]
public class S002215 : ISolution
{
    public object Run(params object[] args)
    {
        return this.FindDifference((int[])args[0], (int[])args[1]);
    }

    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        HashSet<int> nums1Hash = [.. nums1];
        HashSet<int> nums2Hash = [.. nums2];

        IList<IList<int>> result = [[], []];

        foreach (int i in nums1Hash)
        {
            if (!nums2Hash.Contains(i))
            {
                result[0].Add(i);
            }
        }

        foreach (int i in nums2Hash)
        {
            if (!nums1Hash.Contains(i))
            {
                result[1].Add(i);
            }
        }

        return result;
    }
}