using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;

namespace VMFirstNav
{
	public class NavigationService : INavigationService
	{
		INavigation FormsNavigation { 
			get {
				var tabController = App.Current.MainPage as TabbedPage;

				if (tabController != null) {
					return tabController.CurrentPage.Navigation;
				} else {
					return App.Current.MainPage.Navigation;
				}
			}
		}

		// View model to view lookup - making the assumption that view model to view will always be 1:1
		readonly Dictionary<Type, Type> _viewModelViewDictionary = new Dictionary<Type, Type> ();

		public void RegisterViewModels (System.Reflection.Assembly asm)
		{
			// Loop through everything in the assembley that implements IViewFor<T>
			foreach (var type in asm.DefinedTypes.Where(dt => !dt.IsAbstract &&
				dt.ImplementedInterfaces.Any(ii => ii == typeof(IViewFor)))) {

				// Get the IViewFor<T> portion of the type that implements it
				var viewForType = type.ImplementedInterfaces.FirstOrDefault (
					ii => ii.IsConstructedGenericType &&
					ii.GetGenericTypeDefinition () == typeof(IViewFor<>));

				// Register it, using the T as the key and the view as the value
				Register (viewForType.GenericTypeArguments [0], type.AsType ());
			}
		}

		public void Register (Type viewModelType, Type viewType)
		{
			_viewModelViewDictionary.Add (viewModelType, viewType);
		}

		public async Task PopAsync ()
		{				
			await FormsNavigation.PopAsync (true);
		}

		public async Task PopModalAsync ()
		{			
			await FormsNavigation.PopModalAsync (true);
		}

		public async Task PushAsync (BaseViewModel viewModel)
		{
			var view = InstantiateView (viewModel);

			await FormsNavigation.PushAsync ((Page)view);
		}

		public async Task PushModalAsync (BaseViewModel viewModel)
		{
			var view = InstantiateView (viewModel);

			await FormsNavigation.PushModalAsync ((Page)view);
		}

		public async Task PopToRootAsync ()
		{
			await FormsNavigation.PopToRootAsync (true);
		}

		private IViewFor InstantiateView(BaseViewModel viewModel)
		{
			// Figure out what type the view model is
			var viewModelType = viewModel.GetType();

			// look up what type of view it corresponds to
			var viewType = _viewModelViewDictionary[viewModelType];

			// instantiate it
			var view = (IViewFor)Activator.CreateInstance(viewType);

			view.ViewModel = viewModel;

			return view;
		}			
	}
}

