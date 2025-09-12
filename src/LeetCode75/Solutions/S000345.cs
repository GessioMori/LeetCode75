using System.Text;

namespace LeetCode75.Solutions;

[TestCase("AceCreIm", "IceCreAm")]
[TestCase("leetcode", "leotcede")]
public class S000345 : ISolution
{
    private readonly HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

    public object Run(params object[] args)
    {
        return this.ReverseVowels((string)args[0]);
    }

    public string ReverseVowels(string s)
    {
        List<char> vowelsInString = [];

        foreach (char c in s)
        {
            if (vowels.Contains(c.ToString().ToLower()[0]))
            {
                vowelsInString.Add(c);
            }
        }

        int charCount = vowelsInString.Count;
        StringBuilder sb = new();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (vowels.Contains(c.ToString().ToLower()[0]))
            {
                sb.Append(vowelsInString[charCount - 1]);
                charCount--;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}