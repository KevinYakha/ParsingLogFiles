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
        return Regex.Replace(line, @"end-of-line[0-9]+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] badPasswords = new string[lines.Length];
        Regex regex = new Regex(@"password\S+", RegexOptions.IgnoreCase);
        for (int i = 0; i < lines.Length; i++)
        {
            if (regex.IsMatch(lines[i]))
                badPasswords[i] = (regex.Match(lines[i])).Value + ": " + lines[i];
            else
                badPasswords[i] = "--------: " + lines[i];
        }
        return badPasswords;
    }
}
