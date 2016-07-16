using System;
using MvvmHelpers;

namespace VMFirstNav
{
	public interface IMasterListItem<out T> where T : BaseViewModel
	{
	}
}

