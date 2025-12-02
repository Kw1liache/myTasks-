using System;
using System.Collections.Generic;
using System.Linq;
namespace Autocomplete;

public class LeftBorderTask
{
	public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
	{
		if (left + 1 >= right)
			return left;
		var middle = (left + right) / 2;
		if (string.Compare(phrases[middle], prefix, StringComparison.InvariantCultureIgnoreCase) < 0)
			return GetLeftBorderIndex(phrases, prefix, middle, right);
		else
			return GetLeftBorderIndex(phrases, prefix, left, middle);
	}
}
