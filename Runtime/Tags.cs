using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LRT.Utility
{
	[Serializable]
	public abstract class Tags : IEnumerable<string>
	{
		public int mask;

		/// <summary>
		/// All the values corresponding to the mask.
		/// </summary>
		public List<string> Values
		{
			get
			{
				return GetValues(this);
			}
		}

		/// <summary>
		/// All the options available for this tags
		/// </summary>
		public string[] Options
		{
			get
			{
				List<string> tags = GetOptions().Where(t => !string.IsNullOrEmpty(t)).ToList();

				if (tags.Count == 0)
					tags.Add(EmptyOption());

				return tags.ToArray();
			}
		}

		public static List<string> GetValues(Tags tags) => GetValuesFromMask(tags, tags.mask);

		public static List<string> GetValuesFromMask(Tags tags, int mask)
		{
			var selectedValues = new List<string>();

			for (int i = 0; i < tags.Options.Count(); i++)
			{
				// Check if the i-th bit in the mask is set
				if ((mask & (1 << i)) != 0)
				{
					selectedValues.Add(tags.Options[i]);
				}
			}

			return selectedValues;
		}

		protected abstract IEnumerable<string> GetOptions();

		protected virtual string EmptyOption() => "Click edit to add tags";

		public IEnumerator<string> GetEnumerator()
		{
			return Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

