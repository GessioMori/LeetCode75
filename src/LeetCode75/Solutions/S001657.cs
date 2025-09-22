namespace LeetCode75.Solutions;

[TestCase(true, "abc", "bca")]
[TestCase(false, "a", "aa")]
[TestCase(true, "cabbba", "abbccc")]
[TestCase(false, "abbzzca", "babzzcz")]
public class S001657 : ISolution
{
    public object Run(params object[] args)
    {
        return this.CloseStrings((string)args[0], (string)args[1]);
    }

    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;

        if (!word1.ToHashSet().Order().SequenceEqual(word2.ToHashSet().Order())) return false;

        return word1.GroupBy(c => c)
            .ToDictionary(c => c.Key, c => c.Count())
            .Select(c => c.Value)
            .Order()
            .SequenceEqual(word2.GroupBy(c => c)
                .ToDictionary(c => c.Key, c => c.Count())
                .Select(c => c.Value)
                .Order());
    }
}