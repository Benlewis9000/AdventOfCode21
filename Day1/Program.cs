using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
  class Program
  {
    private const string cDay1_1FileName = "input_1.txt";
    private const string cDay1_2FileName = "input_2.txt";
    private const string cResultFilePath = @"..\..\..\result.txt";
    
    static async Task Main(string[] args)
    {
      await Solve(PathAsResource(cDay1_2FileName), cResultFilePath, SolveDay1_2);
    }

    private static string[] SolveDay1_1(string[] input)
    {
      var result = NoOfIncreasingNumbers(ConvertStringsToInts(new List<string>(input)));
      return result.ToString().Split();
    }

    private static string[] SolveDay1_2(string[] input)
    {
      var result = NoOfIncreasingNumbersBy3(ConvertStringsToInts(new List<string>(input)));
      return result.ToString().Split();
    }

    private static async Task Solve(string inputPath, string outputPath, Func<string[], string[]> solve)
    {
      await WriteAllLinesToFile(solve.Invoke(ReadAllLinesFromFile(inputPath).ToArray()), outputPath);
    }

    private static string PathAsResource(string path) => $@"{Environment.CurrentDirectory}\resources\{path}";

    private static int NoOfIncreasingNumbers(IList<int> numbers)
    {
      int increases = 0;
      for (int i = 1; i < numbers.Count; i++)
      {
        if (numbers[i] > numbers[i - 1]) increases++;
      }
      return increases;
    }

    private static int NoOfIncreasingNumbersBy3(IList<int> numbers)
    {
      int increases = 0;
      for (int i = 3; i < numbers.Count; i++)
      {
        if (numbers[i] + numbers[i - 1] + numbers[i - 2] > numbers[i - 1] + numbers[i - 2] + numbers[i - 3])
          increases++;
      }
      return increases;
    }

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
      var ints = new List<int>();
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
      }
      return ints;
    }
  }
}
