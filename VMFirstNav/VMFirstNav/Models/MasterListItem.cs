using System;
using MvvmHelpers;
namespace VMFirstNav
{
	public class MasterListItem<T> : IMasterListItem<T> where T : BaseViewModel
	{
		public string DisplayName { get; set; }

		public MasterListItem(string displayName)
		{
			DisplayName = displayName;
		}
	}
}

