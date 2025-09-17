namespace LeetCode75.Solutions
{
    [TestCase(6, new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' })]
    [TestCase(6, new char[] { 'a', 'a', 'a', 'b', 'b', 'a', 'a' })]
    [TestCase(1, new char[] { 'a' })]
    [TestCase(4, new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' })]
    public class S000443 : ISolution
    {
        public object Run(params object[] args)
        {
            return this.Compress((char[])args[0]);
        }

        public int Compress(char[] chars)
        {
            int writePos = 0;
            int count = 1;

            for (int i = 1; i <= chars.Length; i++)
            {
                if (i < chars.Length && chars[i] == chars[i - 1])
                {
                    count++;
                }
                else
                {
                    chars[writePos++] = chars[i - 1];

                    if (count > 1)
                    {
                        foreach (char c in count.ToString())
                        {
                            chars[writePos++] = c;
                        }
                    }

                    count = 1;
                }
            }

            return writePos;
        }
    }
}