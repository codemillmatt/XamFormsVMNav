using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class TabOneChildView : ContentPage, IViewFor<TabOneChildViewModel>
	{
		TabOneChildViewModel _vm;
		public TabOneChildViewModel ViewModel {
			get { return _vm; }
			set {
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (TabOneChildViewModel)value; }
		}

		public TabOneChildView ()
		{
			InitializeComponent ();
		}
	}
}

