using Shared.Challenge;
using Shared.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Utilities;

namespace Day3
{
  internal class Day3
  {
    public static string InputFilePath => IO.PathAsResource("input.txt");
    public static string OutputDirPath => @"..\..\..\";
    public static string Part1ResultPath => @"..\..\..\result_1.txt";
    public static string Part2ResultPath => @"..\..\..\result_2.txt";

    static async Task Main(string[] args)
    {

      var solution1 = new Solution(input =>
      {
        var lines = input as string[];
        int units = lines[0].Length;

        var ints = Misc.ConvertStringsToInts(lines, 2);

        return CalculatePowerConsumption(ints, units).ToString().Split();
      });
      var problem1 = new Problem(solution1, InputFilePath, Part1ResultPath, 1);
      await problem1.Solve();
    }

    private static int CalculatePowerConsumption(IEnumerable<int> ints, int units)
    {
      int gamma = 0;
      int epsilon = 0;

      for (int pos = 0; pos < units; pos++)
      {
        int scale = 0;
        foreach (var bit in ints.Select(val => val & 1 << pos))
        {
          if (bit == 0)
            scale -= 1;
          else
            scale += 1;
        }

        if (scale > 0)
          epsilon |= 1 << pos;
        else
          gamma |= 1 << pos;
      }

      return gamma * epsilon;
    }

   // private static int CalculateOxygenGeneratorRating();
  }
}
