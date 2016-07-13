using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class TabTwoChildView : ContentPage, IViewFor<TabTwoChildViewModel>
	{
		TabTwoChildViewModel _vm;
		public TabTwoChildViewModel ViewModel {
			get { return _vm; }
			set { 
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (TabTwoChildViewModel)value; }
		}

		public TabTwoChildView ()
		{
			InitializeComponent ();
		}
	}
}

