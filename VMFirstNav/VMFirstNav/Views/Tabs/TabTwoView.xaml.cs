using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class TabTwoView : ContentPage, IViewFor<TabTwoViewModel>
	{
		TabTwoViewModel _vm;

		public TabTwoViewModel ViewModel {
			get { return _vm; }
			set {
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (TabTwoViewModel)value; }
		}

		public TabTwoView ()
		{
			InitializeComponent ();
		}
	}
}

