using System;
namespace WideWorldCalendar.ScheduleFetcher
{
	public class NavigationOption
	{
        public NavigationOption(int id, string name)
        {
            Id = id;
            Name = name;
        }

		public string Name { get; private set; }
		public int Id { get; private set; }
	}
}
