using System;

using Xamarin.Forms;
using Splat;

namespace VMFirstNav
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var mdRoot = new MasterDetailRootPage();
			//var masterNavPage = new MasterListNavPage();
			//masterNavPage.ViewModel = new MasterListNavViewModel();
			//mdRoot.Master = masterNavPage;

			MainPage = mdRoot;

				//MainPage = new MasterDetailRootPage();//RootTabPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

