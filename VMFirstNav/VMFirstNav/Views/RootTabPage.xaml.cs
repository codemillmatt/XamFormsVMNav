using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics.Contracts;

namespace VMFirstNav
{
	public partial class RootTabPage : TabbedPage, IViewFor<RootTabViewModel>
	{

		#region IViewFor

		RootTabViewModel _vm;

		public RootTabViewModel ViewModel
		{
			get
			{
				return _vm;
			}

			set
			{
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel
		{
			get
			{
				return _vm;
			}

			set
			{
				ViewModel = (RootTabViewModel)value;
			}
		}
		#endregion

		public RootTabPage()
		{
			InitializeComponent();

			tabOne.ViewModel = new TabOneViewModel();
			tabTwo.ViewModel = new TabTwoViewModel();
		}
	}



}

