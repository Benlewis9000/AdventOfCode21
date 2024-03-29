﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Shared.Challenge
{
  public class Problem
  {
    private Solution Solution { get; }
    private string InputPath { get; }
    private string OutputPath { get; }

    public Problem(Solution mSolution, string inputPath, string outputDirPath, int part)
    {
      this.Solution = mSolution;
      InputPath = inputPath;
      OutputPath = $"{outputDirPath}/result_{part}.txt";
    }

    public async Task Solve()
    {
      await IO.WriteLinesToFile(Solution.Invoke(IO.ReadAllLinesFromFile(InputPath).ToArray()), OutputPath);
    }
  }
}
