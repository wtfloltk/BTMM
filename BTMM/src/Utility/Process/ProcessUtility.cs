using System.Diagnostics;

namespace BTMM.Utility.Process;

public class ProcessUtility
{
    public static CommandOutput RunProgram(string program, string[] command, string? input = null,
        bool showWindow = false)
    {
        var commandStr = string.Join(" ", command);
        return _RunProcess(program, commandStr, input, showWindow);
    }

    public static CommandOutput RunProgram(string program, string command, string? input = null,
        bool showWindow = false)
    {
        var commandStr = string.Join(" ", command);
        return _RunProcess(program, commandStr, input, showWindow);
    }

    private static CommandOutput _RunProcess(string command, string args, string? input,
        bool showWindow)
    {
        var start = new ProcessStartInfo(command)
        {
            Arguments = args,
            CreateNoWindow = !showWindow,
            ErrorDialog = true,
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            StandardOutputEncoding = System.Text.Encoding.UTF8,
            StandardErrorEncoding = System.Text.Encoding.UTF8
        };

        string? stdout;
        string? stderr;
        using (var p = System.Diagnostics.Process.Start(start))
        {
            if (!string.IsNullOrEmpty(input))
            {
                using var stdin = p?.StandardInput;
                stdin?.Write(input);
            }

            using (var reader = p?.StandardOutput)
            {
                stdout = reader?.ReadToEnd();
                stderr = p?.StandardError.ReadToEnd();
            }
        }

        return new CommandOutput
        {
            Stdout = stdout,
            Stderr = stderr,
        };
    }

    public struct CommandOutput
    {
        public string? Stdout;
        public string? Stderr;
    }
}