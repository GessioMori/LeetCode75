namespace LeetCode75;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class TestCaseAttribute : Attribute
{
    public object[] Inputs { get; }
    public object ExpectedOutput { get; }
    public TestCaseAttribute(object expectedOutput, params object[] inputs)
    {
        ExpectedOutput = expectedOutput;
        Inputs = inputs;
    }
}
