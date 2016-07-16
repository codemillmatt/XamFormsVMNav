using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using Splat;

namespace VMFirstNav
{
	public class NormalOneViewModel : BaseViewModel
	{
		INavigationService _navService;

		public NormalOneViewModel()
		{
			Title = "Normal";

			_navService = Locator.CurrentMutable.GetService<INavigationService>();

			Description = "Normal navigation stack only";
		}

		string _description;
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}

		ICommand _navToChild;
		public ICommand NavigateToChild
		{
			get
			{
				if (_navToChild == null)
				{
					_navToChild = new Command(async () =>
				   {
					   await _navService.PushAsync<NormalOneChildViewModel>((vm) => vm.InitializeDisplay("Normal child!"));
				   }
					);
				}
				return _navToChild;
			}
		}
	}
}

