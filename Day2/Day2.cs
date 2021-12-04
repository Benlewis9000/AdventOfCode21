using Shared.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Day2
{
  public class Day2
  {
    public static string InputPath => IO.PathAsResource("input.txt");
    public static string ResultPath => @"..\..\..\result.txt";

    static async Task Main(string[] args)
    {
      var solution1 = new Solution(input =>
      {
        Position position = new Position();
        foreach(Vector vector in ParseVectors(input)) position.Translate(vector);
        return (position.Horizontal * position.Depth).ToString().Split();
      });

      var problem1 = new Problem(solution1, InputPath, ResultPath);

      await problem1.Solve();
    }

    private static Vector ParseVector(string str)
    {
      string[] args = str.Split(" ");
      // No TryParse - want to know about it if there's an issue 
      return new Vector(int.Parse(args[1]), Enum.Parse<Direction>(args[0], true));
    }

    private static IEnumerable<Vector> ParseVectors(IEnumerable<string> strings)
    {
      return strings.Select(ParseVector);
    }
  }

  internal class Position
  {
    public int Horizontal { get; private set; }
    public int Depth { get; private set; }

    internal void Translate(Vector vector)
    {
      switch (vector.Direction)
      {
        case Direction.Forward:
          Horizontal += vector.Magnitude;
          break;
        case Direction.Down:
          Depth += vector.Magnitude;
          break;
        case Direction.Up:
          Depth -= vector.Magnitude;
          break;
        default:
          throw new ArgumentOutOfRangeException($"No such {nameof(vector)} exists.");
      }
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
