namespace LeetCode75.Solutions
{
    [TestCase(3, "abciiidef", 3)]
    [TestCase(2, "aeiou", 2)]
    [TestCase(2, "leetcode", 3)]
    public class S001456 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.MaxVowels((string)args[0], (int)args[1]);
        }

        public int MaxVowels(string s, int k)
        {
            HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
            int currVowelsCount = 0;

            for (int i = 0; i < k; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    currVowelsCount++;
                }
            }

            int maxVowelsCount = currVowelsCount;

            for (int i = k; i < s.Length; i++)
            {
                currVowelsCount = currVowelsCount - (vowels.Contains(s[i - k]) ? 1 : 0) + (vowels.Contains(s[i]) ? 1 : 0);
                if (currVowelsCount > maxVowelsCount)
                {
                    maxVowelsCount = currVowelsCount;
                }
            }

            return maxVowelsCount;
        }
    }
}