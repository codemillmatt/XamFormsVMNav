using System;
using MvvmHelpers;
using System.Windows.Input;
using Splat;
using Xamarin.Forms;

namespace VMFirstNav
{
	public class TabTwoViewModel : BaseViewModel
	{
		readonly INavigationService _navService;
		public TabTwoViewModel ()
		{
			Title = "Tab Two";

			_navService = Locator.CurrentMutable.GetService<INavigationService> ();
		}

		ICommand _navToChild;
		public ICommand NavigateToChild {
			get {
				if (_navToChild == null)
				{
					_navToChild = new Command(async () =>
					{
						await _navService.PushAsync<TabTwoChildViewModel>();
					});
				}
				return _navToChild;
			}
		}
	}
}

