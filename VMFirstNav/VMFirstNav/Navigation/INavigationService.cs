using System;
using System.Threading.Tasks;
using MvvmHelpers;

namespace VMFirstNav
{
	public interface INavigationService
	{
		void RegisterViewModels(System.Reflection.Assembly asm);
		void Register(Type viewModelType, Type viewType);

		Task PopAsync();
		Task PopModalAsync();
		Task PushAsync(BaseViewModel viewModel);
		Task PushAsync<T>(Action<T> initialize = null) where T : BaseViewModel;
		Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseViewModel;
		Task PushModalAsync(BaseViewModel viewModel);
		Task PopToRootAsync(bool animate);
		//void ReplaceRootWith<T>(Action<T> initialize = null) where T : BaseViewModel;
		//void ReplaceRootWith(BaseViewModel viewModel);
	}
}

