using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class NormalOneChildPage : ContentPage, IViewFor<NormalOneChildViewModel>
	{

		#region IViewFor

		NormalOneChildViewModel _vm;
		public NormalOneChildViewModel ViewModel
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
			set { ViewModel = (NormalOneChildViewModel)value; }
		}

		#endregion

		public NormalOneChildPage()
		{
			InitializeComponent();
		}
	}
}

