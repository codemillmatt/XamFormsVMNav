using System;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Splat;
namespace VMFirstNav
{
	public class MasterListNavViewModel : BaseViewModel
	{
		INavigationService _navService;

		// The overall list that will keep track of which view models can be navigated
		// to and displayed in the "master" portion of master/detail
		public List<IMasterListItem<BaseViewModel>> AvailablePages { get; set; }

		public MasterListNavViewModel()
		{
			_navService = Locator.CurrentMutable.GetService<INavigationService>();

			// This is where we add the view models we can navigate to
			// And the descriptions to be displayed
			AvailablePages = new List<IMasterListItem<BaseViewModel>>();
			AvailablePages.Add(new MasterListItem<NormalOneViewModel>("Normal Nav"));
			AvailablePages.Add(new MasterListItem<RootTabViewModel>("Tab Pages"));

			Title = "Nav";
		}

		ICommand _navCommand;
		public ICommand NavigateCommand
		{
			get
			{
				if (_navCommand == null)
				{
					_navCommand = new Command((selectedItem) =>
					{
						// Get the selected item from the command
						var itemToNavigate = selectedItem as IMasterListItem<BaseViewModel>;

						if (itemToNavigate != null)
						{
							// Get the view model type
							var viewModelType = itemToNavigate.GetType().GenericTypeArguments[0];

							// Get a view model instance
							var viewModel = Activator.CreateInstance(viewModelType) as BaseViewModel;

							// Perform the switch
							_navService.SwitchDetailPage(viewModel);
						}
					});
				}
				return _navCommand;
			}
		}
	}
}

