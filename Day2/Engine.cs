using System;
using System.Collections.Generic;

namespace Day2
{
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
}