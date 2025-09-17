namespace LeetCode75.Solutions
{
    [TestCase(true, "abc", "ahbgdc")]
    [TestCase(false, "axc", "ahbgdc")]
    public class S000392 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.IsSubsequence((string)args[0], (string)args[1]);
        }

        public bool IsSubsequence(string s, string t)
        {
            int cursor = 0;
            bool hasFoundChar = false;

            for (int i = 0; i < s.Length; i++)
            {
                for (; cursor < t.Length; cursor++)
                {
                    if (t[cursor] == s[i])
                    {
                        hasFoundChar = true;
                        cursor++;
                        break;
                    }
                }

                if (!hasFoundChar) return false;
                hasFoundChar = false;
            }

            return true;
        }
    }
}