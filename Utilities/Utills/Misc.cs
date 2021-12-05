using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Utills
{
  public class Misc
  {
    public static List<int> ConvertStringsToInts(IEnumerable<string> strings)
    {
      return strings.Select(str => str.ToInt()).ToList();
    }
  }
}
