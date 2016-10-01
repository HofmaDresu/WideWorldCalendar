﻿using System;
using System.Collections.Generic;

namespace WideWorldCalendar.ScheduleFetcher
{
	public static class ScheduleHtmlParser
	{
		// Yield returns aren't really needed, but it was fun to write them

		public static IEnumerable<string> GetSeasons(string html)
		{
			var seasonSections = html.Split(new[] { "Season: </strong>" }, StringSplitOptions.RemoveEmptyEntries);

			if (seasonSections.Length <=1) yield break;

			for (int i = 1; i < seasonSections.Length; i++)
			{
				var section = seasonSections[i];
				var sectionName = section.Substring(0, section.IndexOf('<'));
				yield return CleanString(sectionName);
			}
		}

		private static string CleanString(string source)
		{
			return source.Replace("\n", "").Trim();
		}
	}
}
