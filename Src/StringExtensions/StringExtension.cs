using System;

namespace StringExtensions
{
	public static class StringExtension
	{
		public static bool SpanSearcherContains(ReadOnlySpan<char> stringToSearch, string searchFor, int startAt = 0, int endAt = -1)
		{
			if (stringToSearch == null) return false;
			if (stringToSearch.IsEmpty) return false;
			if ( searchFor == null ) return false;
			if ( searchFor == String.Empty) return false;

			ReadOnlySpan<char> lookingFor = searchFor;
			if (endAt == -1) endAt = stringToSearch.Length;

			// Search the relevant string slice for that value
			for ( int i = startAt; i <= endAt - lookingFor.Length; i++ ) {
				if ( stringToSearch.Slice(i, lookingFor.Length).SequenceEqual(lookingFor) ) return true;
			}

			return false;
		}
	}
}
