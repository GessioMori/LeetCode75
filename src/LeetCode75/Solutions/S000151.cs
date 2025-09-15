namespace LeetCode75.Solutions
{
    [TestCase("blue is sky the", "the sky is blue")]
    [TestCase("world hello", "  hello world  ")]
    [TestCase("example good a", "a good   example")]
    public class S000151 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.ReverseWords((string)args[0]);
        }

        public string ReverseWords(string s)
        {
            return string.Join(' ', s
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Reverse());
        }
    }
}