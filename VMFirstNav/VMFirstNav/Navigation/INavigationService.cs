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
		Task PushModalAsync(BaseViewModel viewModel);
		Task PopToRootAsync();
	}
}

