using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Splat;

namespace VMFirstNav.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			INavigationService navService = new NavigationService ();
			navService.RegisterViewModels (typeof(RootTabPage).Assembly);

			Locator.CurrentMutable.RegisterConstant (navService, typeof(INavigationService));
		
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

