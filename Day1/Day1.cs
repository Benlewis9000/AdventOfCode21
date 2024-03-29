﻿using Shared.Challenge;
using Shared.Extensions;
using Shared.Utills;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Day1
{
  class Day1
  {
    public static string InputFilePath => IO.PathAsResource("input.txt");
    public static string OutputDirPath => @"..\..\..\";

    static async Task Main(string[] args)
    {
      var solution1 = new Solution(input => NoOfIncreasingNumbers(Misc.ConvertStringsToInts(new List<string>(input))).ToString().Split());
      var solution2 = new Solution(input => NoOfIncreasingNumbersBy3(Misc.ConvertStringsToInts(new List<string>(input))).ToString().Split());

      var part1 = new Problem(solution1, InputFilePath, OutputDirPath, 1);
      var part2 = new Problem(solution2, InputFilePath, OutputDirPath, 2);

      await part1.Solve();
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
  }
}
