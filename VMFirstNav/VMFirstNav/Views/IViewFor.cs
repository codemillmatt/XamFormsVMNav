using System;
using MvvmHelpers;

namespace VMFirstNav
{
	public interface IViewFor
	{
		object ViewModel { get; set; }
	}

	public interface IViewFor<T> : IViewFor where T : BaseViewModel 
	{
		T ViewModel { get; set; }
	}
}

