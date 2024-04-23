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
        throw new NotImplementedException($"Please implement the LogParser.SplitLogLine() method");
    }

    public int CountQuotedPasswords(string lines)
    {
        throw new NotImplementedException($"Please implement the LogParser.CountQuotedPasswords() method");
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
