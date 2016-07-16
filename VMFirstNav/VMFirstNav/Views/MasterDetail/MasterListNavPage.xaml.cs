using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class MasterListNavPage : ContentPage, IViewFor<MasterListNavViewModel>
	{
		public MasterListNavPage()
		{
			InitializeComponent();
		}

		#region IViewFor

		MasterListNavViewModel _vm;
		public MasterListNavViewModel ViewModel
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
				ViewModel = (MasterListNavViewModel)value;
			}
		}
		#endregion
	}
}

