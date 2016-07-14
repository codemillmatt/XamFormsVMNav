using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class NormalOnePage : ContentPage, IViewFor<NormalOneViewModel>
	{
		#region IViewFor

		NormalOneViewModel _vm;
		public NormalOneViewModel ViewModel
		{
			get { return _vm; }
			set
			{
				_vm = value;
				BindingContext = _vm;
			}
		}

		object IViewFor.ViewModel
		{
			get { return _vm; }
			set { ViewModel = (NormalOneViewModel)value; }
		}

		#endregion

		public NormalOnePage()
		{
			InitializeComponent();
		}
	}
}

