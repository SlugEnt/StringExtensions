using System;

namespace StringExtensions
{
	/// <summary>
	/// A set of string extensions.
	/// </summary>
	public static class StringExtension
	{
		/// <summary>
		/// Performs the fastest possible string searches, especially on larger strings for a given string
		/// </summary>
		/// <param name="stringToSearch">The string to be searched</param>
		/// <param name="searchFor">The string you are looking for</param>
		/// <param name="startAt">The position in the string to be searched to start searching.  Allows you to skip a certain number of characters</param>
		/// <param name="endAt">The position in string to stop searching at.</param>
		/// <returns></returns>
		public static bool SpanSearcherContains(ReadOnlySpan<char> stringToSearch, string searchFor, int startAt = 0, int endAt = -1)
		{
			// Test for empty / null
			if (stringToSearch == null) return false;
			if (stringToSearch.IsEmpty) return false;
			if ( searchFor == null ) return false;
			if ( searchFor == String.Empty) return false;

			// Some validations
			if (startAt < 0) throw new ArgumentException("Starting Index must be positive number");
			if (endAt < -1) throw new ArgumentException("Ending Index must be positive number");
			if (startAt > stringToSearch.Length ) return false;
			if (endAt == -1) endAt = stringToSearch.Length;
			if (endAt < startAt) throw new ArgumentException("Ending index cannot be less than the starting index");
			if (endAt > stringToSearch.Length ) endAt = stringToSearch.Length;

			ReadOnlySpan<char> lookingFor = searchFor;
			

			// Search the relevant string slice for that value
			for ( int i = startAt; i <= endAt - lookingFor.Length; i++ ) {
				if ( stringToSearch.Slice(i, lookingFor.Length).SequenceEqual(lookingFor) ) return true;
			}

			return false;
		}
	}
}
