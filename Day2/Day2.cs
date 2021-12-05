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
      var solution1 = new Solution(input =>
      {
        Position position = new Position(Engine.BuildSimpleEngine());
        foreach(Vector vector in ParseVectors(input)) position.Translate(vector);
        return (position.Horizontal * position.Depth).ToString().Split();
      });
      var problem1 = new Problem(solution1, InputPath, ResultPath);
      //await problem1.Solve();

      var solution2 = new Solution(input =>
      {
        Position position = new Position(Engine.BuildAimEngine());
        foreach (Vector vector in ParseVectors(input)) position.Translate(vector);
        return (position.Horizontal * position.Depth).ToString().Split();
      });
      var problem2 = new Problem(solution2, InputPath, ResultPath);
      await problem2.Solve();
    }

    private static Vector ParseVector(string str)
    {
      string[] args = str.Split(" ");
      return new Vector(int.Parse(args[1]), Enum.Parse<Direction>(args[0], true));
    }

    private static IEnumerable<Vector> ParseVectors(IEnumerable<string> strings)
    {
      return strings.Select(ParseVector);
    }
  }

  internal class Position
  {
    public int Horizontal { get; internal set; }
    public int Depth { get; internal set; }
    public int Aim { get; internal set; }
    private Engine Engine { get; }

    public Position(Engine engine)
    {
      Engine = engine;
    }

    internal void Translate(Vector vector)
    { 
      Engine.Get(vector.Direction).Invoke(this, vector.Magnitude);
    }
  }

  internal class Engine
  {
    private Dictionary<Direction, Action<Position, int>> Actions { get; }

    private Engine(Dictionary<Direction, Action<Position, int>> actions = null)
    {
      Actions = actions ?? new Dictionary<Direction, Action<Position, int>>();
    }

    // Used in part 1
    public static Engine BuildSimpleEngine()
    {
      return new Engine()
        .Put(Direction.Forward, (pos, mag) => pos.Horizontal += mag)
        .Put(Direction.Down, (pos, mag) => pos.Depth += mag)
        .Put(Direction.Up, (pos, mag) => pos.Depth -= mag);
    }

    // Used in part 2
    public static Engine BuildAimEngine()
    {
      return new Engine()
        .Put(Direction.Forward, (pos, mag) =>
        {
          pos.Horizontal += mag;
          pos.Depth += pos.Aim * mag;
        })
        .Put(Direction.Down, (pos, mag) => pos.Aim += mag)
        .Put(Direction.Up, (pos, mag) => pos.Aim -= mag);
    }

    public Engine Put(Direction direction, Action<Position, int> action)
    {
      Actions[direction] = action;
      return this;
    }

    public Action<Position, int> Get(Direction direction)
    {
      return Actions[direction];
    }
  }

  internal enum Direction
  {
    Forward,
    Down,
    Up
  }

  internal class Vector
  {
    public int Magnitude { get; }
    public Direction Direction { get; }

    internal Vector(int magnitude, Direction direction)
    {
      Magnitude = magnitude;
      Direction = direction;
    }
  }
}
