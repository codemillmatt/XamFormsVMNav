using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class TabOneView : ContentPage, IViewFor<TabOneViewModel>
	{
		TabOneViewModel _vm;
		public TabOneViewModel ViewModel {
			get { return _vm; }
			set { 
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (TabOneViewModel)value; }
		}

		public TabOneView ()
		{
			InitializeComponent ();
		}
	}
}

