using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class NormalModalPage : ContentPage, IViewFor<NormalModalViewModel>
	{
		#region IViewFor

		NormalModalViewModel _vm;

		public NormalModalViewModel ViewModel
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
			set
			{
				ViewModel = (NormalModalViewModel)value;
			}
		}

		#endregion

		public NormalModalPage()
		{
			InitializeComponent();
		}
	}
}

