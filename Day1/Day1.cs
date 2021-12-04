using Shared.Challenge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utilities;

namespace Day1
{
  class Day1
  {
    public static string InputPath => IO.PathAsResource("input.txt");
    public static string ResultPath => @"..\..\..\result.txt";

    static async Task Main(string[] args)
    {
      var solution1 = new Solution(input => NoOfIncreasingNumbers(ConvertStringsToInts(new List<string>(input))).ToString().Split());
      var solution2 = new Solution(input => NoOfIncreasingNumbersBy3(ConvertStringsToInts(new List<string>(input))).ToString().Split());

      var part1 = new Problem(solution1, InputPath, ResultPath);
      var part2 = new Problem(solution2, InputPath, ResultPath);
      await part2.Solve();
    }

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
        if (numbers[i] + numbers[i - 1] + numbers[i - 2] 
            > numbers[i - 1] + numbers[i - 2] + numbers[i - 3])
          increases++;
      }
      return increases;
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
