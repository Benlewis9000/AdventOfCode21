using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shared.Extensions
{
  public static class StringExtension
  {
    public static int ToInt(this string str)
    {
      if (!int.TryParse(str, out int i))
      {
        throw new FormatException($"Failed to read int {str}, discarding.");
      }
      return i;
    }
  }
}
