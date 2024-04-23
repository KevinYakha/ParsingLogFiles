using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        Regex regex = new Regex(@"^\[TRC\]|^\[DBG\]|^\[INF\]|^\[WRN\]|^\[ERR\]|^\[FTL\]");
        if(regex.IsMatch(text))
            return true;
        return false;
    }

    public string[] SplitLogLine(string text)
    {
        // any string that has a first character of "<" and a last character of ">"
        // and any combination of the following characters "^", "*", "=" and "-" in between
        return Regex.Split(text, @"\<[\^\*\=\-]+\>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Count(lines, @""".*password.*""", RegexOptions.IgnoreCase);
    }

    public string RemoveEndOfLineText(string line)
    {
        throw new NotImplementedException($"Please implement the LogParser.RemoveEndOfLineText() method");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        throw new NotImplementedException($"Please implement the LogParser.ListLinesWithPasswords() method");
    }
}
