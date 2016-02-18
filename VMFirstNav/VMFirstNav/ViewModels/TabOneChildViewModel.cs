using System;
using MvvmHelpers;
using System.Windows.Input;
using Splat;
using Xamarin.Forms;

namespace VMFirstNav
{
	public class TabOneChildViewModel : BaseViewModel
	{
		readonly INavigationService _navService;
		public TabOneChildViewModel ()
		{
			Title = "Tab One Child";

			_navService = Locator.CurrentMutable.GetService<INavigationService> ();
		}

		ICommand _navToParent;
		public ICommand NavigateBack {
			get {
				if (_navToParent == null) {
					_navToParent = new Command (async () => 
						await _navService.PopAsync()
					);
				}
				return _navToParent;
			}
		}
	}
}

