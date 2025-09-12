using Spectre.Console;
using System.Collections;

namespace LeetCode75;

internal class Program
{
    private const string solutionsFolder = "Solutions";
    private const string templatesFolder = "Templates";
    private const string solutionTemplateFileName = "solution-template.txt";
    private const string lastExecutedFileName = "last.txt";
    private const int paddingLength = 6;

    private static void Main(string[] args)
    {
        bool shouldExit = false;

        while (!shouldExit)
        {
            try
            {
                int lastRun = ReadLastRun();

                List<string> choices = ["Run by number", "Create new", "Exit"];

                if (lastRun != -1)
                {
                    choices.Insert(0, $"Run last ({lastRun})");
                }

                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an option")
                        .AddChoices(choices));

                switch (choice)
                {
                    case string s when s.StartsWith("Run last"):
                        int problemNumber = int.Parse(s.Split('(', ')')[1]);
                        RunByNumber(problemNumber);
                        break;

                    case "Run by number":
                        RunByNumberInput();
                        break;

                    case "Create new":
                        CreateNew();
                        break;

                    case "Exit":
                        shouldExit = true;
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Unknown choice[/]");
                        break;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            }
        }
    }

    private static void CreateNew()
    {
        int problemNumberToInitialize = AnsiConsole.Prompt(new TextPrompt<int>("Problem number: "));

        CreateSolutionFile(problemNumberToInitialize);
    }

    private static void RunByNumberInput()
    {
        int problemNumberToRun = AnsiConsole.Prompt(new TextPrompt<int>("Problem number: "));

        RunByNumber(problemNumberToRun);
    }

    private static void RunByNumber(int problemNumberToRun)
    {
        ISolution? solution = CreateSolutionInstance(problemNumberToRun);
        if (solution == null)
        {
            AnsiConsole.MarkupLine($"[red]Solution {problemNumberToRun} not found.[/]");
            return;
        }

        Type type = solution.GetType();
        List<TestCaseAttribute> testCases = [.. type.GetCustomAttributes(typeof(TestCaseAttribute), true).Cast<TestCaseAttribute>()];

        if (testCases.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No test cases defined.[/]");
            return;
        }

        Table table = new()
        {
            Border = TableBorder.Rounded
        };

        table.AddColumn("Output");
        table.AddColumn("Expected");
        table.AddColumn("Result");

        foreach (TestCaseAttribute? test in testCases)
        {
            object result = solution.Run(test.Inputs);

            bool ok = (result is Array a && test.ExpectedOutput is Array e && a.Cast<object>().SequenceEqual(e.Cast<object>()))
                      || (result is IEnumerable ie && test.ExpectedOutput is IEnumerable ee && ie.Cast<object>().SequenceEqual(ee.Cast<object>()))
                      || Equals(result, test.ExpectedOutput);

            Markup status = ok ? new Markup("[green]Passed[/]") : new Markup("[red]Failed[/]");

            table.AddRow(
                new Markup(Format(result)),
                new Markup(Format(test.ExpectedOutput)),
                status
            );
        }

        SaveLastRun(problemNumberToRun);
        AnsiConsole.Write(table);
    }

    private static string Format(object obj)
    {
        if (obj is Array arr)
        {
            return string.Join(", ", arr.Cast<object>());
        }

        if (obj is IEnumerable enumerable && obj.GetType().IsGenericType)
        {
            return string.Join(", ", enumerable.Cast<object>());
        }

        return obj?.ToString() ?? "null";
    }

    public static string? FindProjectFolder()
    {
        DirectoryInfo? currentDir = new(AppContext.BaseDirectory);

        while (currentDir != null)
        {
            if (Directory.GetFiles(currentDir.FullName, "*.csproj").Length > 0)
            {
                return currentDir.FullName;
            }
            currentDir = currentDir.Parent;
        }

        return null;
    }

    private static void CreateSolutionFile(int problemNumber)
    {
        string? basePath = FindProjectFolder();

        if (string.IsNullOrEmpty(basePath)) return;

        string formatedSolutionNumber = $"S{problemNumber.ToString().PadLeft(paddingLength, '0')}";
        string folderPath = Path.Combine(basePath, solutionsFolder);
        string filePath = Path.Combine(folderPath, formatedSolutionNumber + ".cs");

        Directory.CreateDirectory(folderPath);

        string templatePath = Path.Combine(templatesFolder, solutionTemplateFileName);
        string templateContent = File.ReadAllText(templatePath);

        string formatedTemplate = string.Format(templateContent, formatedSolutionNumber);

        File.WriteAllText(filePath, formatedTemplate);
    }

    private static int ReadLastRun()
    {
        string? basePath = FindProjectFolder();

        if (string.IsNullOrEmpty(basePath)) return -1;

        string filePath = Path.Combine(basePath, lastExecutedFileName);
        try
        {
            if (!File.Exists(filePath)) return -1;

            string content = File.ReadAllText(filePath);

            if (int.TryParse(content, out int lastRun))
            {
                return lastRun;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read last run: {ex.Message}");
        }

        return -1;
    }

    private static ISolution? CreateSolutionInstance(int problemNumber)
    {
        string typeName = $"LeetCode75.Solutions.S{problemNumber.ToString().PadLeft(paddingLength, '0')}";
        Type? type = Type.GetType(typeName);

        if (type == null) return null;

        ISolution? instance = Activator.CreateInstance(type) as ISolution;
        return instance;
    }
    private static void SaveLastRun(int solutionNumber)
    {
        string? basePath = FindProjectFolder();

        if (string.IsNullOrEmpty(basePath)) return;

        string filePath = Path.Combine(basePath, lastExecutedFileName);

        try
        {
            File.WriteAllText(filePath, solutionNumber.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write last run: {ex.Message}");
        }
    }
}
