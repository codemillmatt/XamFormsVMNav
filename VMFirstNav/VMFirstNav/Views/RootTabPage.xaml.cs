using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VMFirstNav
{
	public partial class RootTabPage : TabbedPage
	{
		public RootTabPage ()
		{
			InitializeComponent ();

			tabOne.ViewModel = new TabOneViewModel ();
			tabTwo.ViewModel = new TabTwoViewModel ();
		}
	}
}

