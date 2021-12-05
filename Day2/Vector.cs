using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
  internal class Vector
  {
    public int Magnitude { get; }
    public Direction Direction { get; }

    internal Vector(int magnitude, Direction direction)
    {
      Magnitude = magnitude;
      Direction = direction;
    }

    internal static Vector ParseVector(string str)
    {
      string[] args = str.Split(" ");
      return new Vector(int.Parse(args[1]), Enum.Parse<Direction>(args[0], true));
    }

    internal static IEnumerable<Vector> ParseVectors(IEnumerable<string> strings)
    {
      return strings.Select(ParseVector);
    }
  }
}