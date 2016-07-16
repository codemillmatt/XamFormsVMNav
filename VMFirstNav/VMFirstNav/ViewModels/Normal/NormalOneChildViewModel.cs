using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using Splat;

namespace VMFirstNav
{
	public class NormalOneChildViewModel : BaseViewModel
	{
		INavigationService _navService;
		public NormalOneChildViewModel()
		{
			Title = "Normal Child";

			_navService = Locator.CurrentMutable.GetService<INavigationService>();
		}

		public void InitializeDisplay(string description)
		{
			Description = description;
		}

		string _description;
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}

		ICommand _navToChild;
		public ICommand NavigatePopup
		{
			get
			{
				if (_navToChild == null)
				{
					_navToChild = new Command(async () =>
				   {
					   await _navService.PushModalAsync<NormalModalViewModel>();
				   });
				}
				return _navToChild;
			}
		}
	}
}

