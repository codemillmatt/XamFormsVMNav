using System;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;
using Splat;
namespace VMFirstNav
{
	public class NormalModalViewModel : BaseViewModel
	{
		INavigationService _navService;

		public NormalModalViewModel()
		{
			Title = "Normal Modal";

			_navService = Locator.CurrentMutable.GetService<INavigationService>();
		}

		ICommand _dismissModal;
		public ICommand DismissModalCommand
		{
			get
			{
				if (_dismissModal == null)
				{
					_dismissModal = new Command(async () => await _navService.PopModalAsync());
				}
				return _dismissModal;
			}
		}
	}
}

