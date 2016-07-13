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
		INavigation FormsNavigation
		{
			get
			{
				var tabController = App.Current.MainPage as TabbedPage;

				if (tabController != null)
				{
					return tabController.CurrentPage.Navigation;
				}
				else {
					return Application.Current.MainPage.Navigation;
				}
			}
		}

		// View model to view lookup - making the assumption that view model to view will always be 1:1
		readonly Dictionary<Type, Type> _viewModelViewDictionary = new Dictionary<Type, Type>();

		#region Registration

		public void RegisterViewModels(System.Reflection.Assembly asm)
		{
			// Loop through everything in the assembley that implements IViewFor<T>
			foreach (var type in asm.DefinedTypes.Where(dt => !dt.IsAbstract &&
				dt.ImplementedInterfaces.Any(ii => ii == typeof(IViewFor))))
			{

				// Get the IViewFor<T> portion of the type that implements it
				var viewForType = type.ImplementedInterfaces.FirstOrDefault(
					ii => ii.IsConstructedGenericType &&
					ii.GetGenericTypeDefinition() == typeof(IViewFor<>));

				// Register it, using the T as the key and the view as the value
				Register(viewForType.GenericTypeArguments[0], type.AsType());
			}
		}

		public void Register(Type viewModelType, Type viewType)
		{
			_viewModelViewDictionary.Add(viewModelType, viewType);
		}

		#endregion

		#region Pop

		public async Task PopAsync()
		{
			await FormsNavigation.PopAsync(true);
		}

		public async Task PopModalAsync()
		{
			await FormsNavigation.PopModalAsync(true);
		}

		public async Task PopToRootAsync(bool animate)
		{
			await FormsNavigation.PopToRootAsync(animate);
		}

		#endregion

		#region Push

		public async Task PushAsync(BaseViewModel viewModel)
		{
			var view = InstantiateView(viewModel);

			await FormsNavigation.PushAsync((Page)view);
		}

		public async Task PushModalAsync(BaseViewModel viewModel)
		{
			var view = InstantiateView(viewModel);

			// Most likely we're going to want to put this into a navigation page so we can have a title bar on it
			var nv = new NavigationPage((Page)view);

			await FormsNavigation.PushModalAsync(nv);
		}

		public async Task PushAsync<T>(Action<T> initialize = null) where T : BaseViewModel
		{
			T viewModel;

			// Instantiate the view model & invoke the initialize method, if any
			viewModel = Activator.CreateInstance<T>();
			initialize?.Invoke(viewModel);

			await PushAsync(viewModel);
		}

		public async Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseViewModel
		{
			T viewModel;

			// Instantiate the view model & invoke the initialize method, if any
			viewModel = Activator.CreateInstance<T>();
			initialize?.Invoke(viewModel);

			await PushModalAsync(viewModel);
		}

		#endregion

		IViewFor InstantiateView(BaseViewModel viewModel)
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

