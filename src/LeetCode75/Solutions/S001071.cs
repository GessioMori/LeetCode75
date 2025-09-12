namespace LeetCode75.Solutions
{
    [TestCase("ABC", "ABCABC", "ABC")]
    [TestCase("AB", "ABABAB", "ABAB")]
    [TestCase("", "LEET", "CODE")]
    public class S001071 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.GcdOfStrings((string)args[0], (string)args[1]);
        }

        private string GcdOfStrings(string str1, string str2)
        {
            for (int i = Math.Min(str1.Length, str2.Length); i > 0; i--)
            {
                if (str1.Length % i == 0 && str2.Length % i == 0)
                {
                    string candidate = str1[..i];
                    if (IsDivisible(str1, candidate) && IsDivisible(str2, candidate))
                    {
                        return candidate;
                    }
                }
            }

            return string.Empty;
        }

        private bool IsDivisible(string str, string candidate)
        {
            for (int i = 0; i < str.Length; i += candidate.Length)
            {
                if (str[i..(i + candidate.Length)] != candidate)
                {
                    return false;
                }
            }
            return true;
        }
    }
}