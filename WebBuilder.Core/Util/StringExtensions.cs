using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBuilder.Core.Util
{
  public static  class StringExtensions
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
