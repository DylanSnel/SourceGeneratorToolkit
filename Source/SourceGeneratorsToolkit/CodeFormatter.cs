using System.Text;

namespace SourceGeneratorsToolkit;

public static class CodeFormatter
{
    /// <summary>
    /// Formats the source code to match the desired indentation width
    /// Its not perfect but much easier.
    /// </summary>
    /// <param name="sourceCode"></param>
    /// <returns>The formatted code</returns>
    public static string FormatSourceCode(string sourceCode)
    {
        var formattedCode = new StringBuilder();
        int indentationLevel = 0;
        bool lambda = false;
        const int spacesPerIndent = 4; // Adjust this to match your desired indentation width

        foreach (var line in sourceCode.Split(['\r', '\n']))
        {

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            // Decrease indentation if the line closes a scope
            if (line.TrimStart().StartsWith("}"))
                indentationLevel--;

            if (line.TrimStart().StartsWith("=>"))
            {
                indentationLevel++;
                lambda = true;
            }


            // Apply current indentation
            formattedCode.AppendLine(new string(' ', spacesPerIndent * indentationLevel) + line.TrimStart());
            if (line.TrimEnd().EndsWith("}"))
                formattedCode.AppendLine();

            // Increase indentation if the line opens a scope
            if (line.TrimEnd().EndsWith("{"))
                indentationLevel++;

            if (lambda && line.TrimStart().EndsWith(";"))
            {
                indentationLevel--;
                lambda = false;
                formattedCode.AppendLine();
            }
        }

        return formattedCode.ToString().TrimEnd();
    }
}
