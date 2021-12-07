using Shared.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Day2
{
  // Note that exceptions related to input/parsing are not handled as these problems should be know
  // TODO: Could handle and nicely inform user of bad input thus no output rather than just breaking,
  //        in fact this may be preferable so out of date results aren't accidentally reused.
  public class Day2
  {
    public static string InputPath => IO.PathAsResource("input.txt");
    public static string ResultPath => @"..\..\..\result.txt";

    static async Task Main(string[] args)
    {
      // Part 1
      var solution1 = new Solution(input =>
      {
        Position position = new Position(Engine.BuildSimpleEngine());
        foreach(Vector vector in Vector.ParseVectors(input)) position.Translate(vector);
        return (position.Horizontal * position.Depth).ToString().Split();
      });
      var problem1 = new Problem(solution1, InputPath, ResultPath);
      await problem1.Solve();

      // Part 2
      var solution2 = new Solution(input =>
      {
        Position position = new Position(Engine.BuildAimEngine());
        foreach (Vector vector in Vector.ParseVectors(input)) position.Translate(vector);
        return (position.Horizontal * position.Depth).ToString().Split();
      });
      var problem2 = new Problem(solution2, InputPath, ResultPath);
      await problem2.Solve();
    }
  }
}
