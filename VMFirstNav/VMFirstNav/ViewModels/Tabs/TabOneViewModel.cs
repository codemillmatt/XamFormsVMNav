using System;
using MvvmHelpers;
using System.Windows.Input;
using Splat;
using Xamarin.Forms;

namespace VMFirstNav
{
	public class TabOneViewModel : BaseViewModel
	{
		readonly INavigationService _navService;
		public TabOneViewModel ()
		{
			Title = "Tab One";

			_navService = Locator.CurrentMutable.GetService<INavigationService> ();
		}

		ICommand _navToChild;
		public ICommand NavigateToChild {
			get {
				if (_navToChild == null) {
					_navToChild = new Command (async () =>
					{
						await _navService.PushAsync<TabOneChildViewModel>((vm) => vm.InitializeDisplay("Title from initialization routine"));
					}
					);
				}
				return _navToChild;
			}
		}
	}
}

