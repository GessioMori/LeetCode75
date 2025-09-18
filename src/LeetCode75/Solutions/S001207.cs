
namespace LeetCode75.Solutions;

[TestCase(true, new int[] { 1, 2, 2, 1, 1, 3 })]
[TestCase(false, new int[] { 1, 2 })]
[TestCase(true, new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 })]
public class S001207 : ISolution
{
    public object Run(params object[] args)
    {
        return this.UniqueOccurrences((int[])args[0]);
    }

    public bool UniqueOccurrences(int[] arr)
    {
        List<int> occurences = arr.GroupBy(x => x).Select(g => g.Count()).ToList();

        return occurences.Count == occurences.Distinct().Count();
    }
}