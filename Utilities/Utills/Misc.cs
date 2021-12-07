using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Utills
{
  public class Misc
  {
    public static List<int> ConvertStringsToInts(IEnumerable<string> strings, int bse = 10)
    {
      return strings.Select(str => Convert.ToInt32(str, bse)).ToList();
    }
  }
}
