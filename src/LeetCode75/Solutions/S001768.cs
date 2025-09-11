using System.Text;

namespace LeetCode75.Solutions
{
    [TestCase("apbqcr", "abc", "pqr")]
    [TestCase("apbqrs", "ab", "pqrs")]
    public class S001768 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.MergeAlternately((string)args[0], (string)args[1]);
        }

        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder sb = new();
            int current = 0;

            while (current < word1.Length && current < word2.Length)
            {
                sb.Append(word1[current]);
                sb.Append(word2[current]);

                current++;
            }

            if (word1.Length > word2.Length)
            {
                sb.Append(word1[current..]);
            }
            else if (word2.Length > word1.Length)
            {
                sb.Append(word2[current..]);
            }

            return sb.ToString();
        }
    }
}