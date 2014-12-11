using System;
using Xamarin.Forms;
using MedConnect.NewViews;

namespace MedConnect
{
	public class RootPage : NavigationPage
	{
		public RootPage ()
		{
			this.BackgroundColor = Color.Fuschia;
			Navigation.PushAsync (new SplashScreen ());

			App.MasterPage = new MasterPage ();

			this.PoppedToRoot += (sender, args) =>
			{
				if (App.User == null) {
					this.Navigation.PushModalAsync (new LoginPage ());			
				} else {
					this.Navigation.PushModalAsync (App.MasterPage);
				}
			};
		}
	}
}

