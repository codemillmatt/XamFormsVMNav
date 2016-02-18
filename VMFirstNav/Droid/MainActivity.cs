using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Splat;

namespace VMFirstNav.Droid
{
	[Activity (Label = "VMFirstNav.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			INavigationService navService = new NavigationService ();
			navService.RegisterViewModels (typeof(RootTabPage).Assembly);

			Locator.CurrentMutable.RegisterConstant (navService, typeof(INavigationService));

			LoadApplication (new App ());
		}
	}
}

