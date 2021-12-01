using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
  class Program
  {
    static readonly string cDay1FileName = "input_1.txt";
    static readonly string cResultFilePath = @"C:\Users\benja\source\repos\AdventOfCode21\Day1\result.txt";


    static async Task Main(string[] args)
    {
      var input1 = ReadAllLinesFromFile(PathAsResource(cDay1FileName));
      var numbers = ConvertStringsToInts(input1);

      int increases = 0;
      for(int i = 1; i < numbers.Count; i++)
      {
        if (numbers[i] > numbers[i - 1]) increases++;
      }
      Console.WriteLine(increases);
      await WriteLineToFile(increases.ToString(), cResultFilePath);
    }

    private static string PathAsResource(string path) => $@"{Environment.CurrentDirectory}\resources\{path}";

    private static List<string> ReadAllLinesFromFile(string filePath)
    {
      try
      {
        return File.ReadAllLines(filePath).ToList();
      }
      catch (IOException e)
      {
        throw e;
      }
    }

    private static async Task WriteLineToFile(string line, string filePath)
    {
      // TODO this is a bit nasty, probably a better option
      await WriteAllLinesToFile(new[] { line }, filePath);
    }

    private static async Task WriteAllLinesToFile(string[] lines, string filePath)
    {
      using StreamWriter file = new StreamWriter(filePath);

      foreach (string line in lines)
      {
        await file.WriteLineAsync(line);
      }
    }

    private static List<int> ConvertStringsToInts(List<string> strings)
    {
      List<int> ints = new List<int>();
      foreach (var str in strings)
      {
        try
        {
          ints.Add(int.Parse(str));
        }
        catch (FormatException)
        {
          Console.WriteLine($"Failed to read int {str}, discarding.");
        }
        catch (Exception e)
        {
          throw e;
        }
      }
      return ints;
    }
  }
}
