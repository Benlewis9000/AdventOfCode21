using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities
{
  public static class IO
  {
    public static IEnumerable<string> ReadAllLinesFromFile(string filePath)
    {
      return File.ReadAllLines(filePath).ToList();
    }

    public static string PathAsResource(string path) => $@"{Environment.CurrentDirectory}\resources\{path}";

    public static async Task WriteLinesToFile(string line, string filePath)
    {
      await WriteLinesToFile(new[] { line }, filePath);
    }

    public static async Task WriteLinesToFile(IEnumerable<string>lines, string filePath)
    {
      await using StreamWriter file = new StreamWriter(filePath);

      foreach (string line in lines)
      {
        await file.WriteLineAsync(line);
      }
    }
  }
}