using System;
using Xamarin.Forms;
using MedConnect.NewViews;

namespace MedConnect
{
	public class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
			this.BackgroundColor = Color.Blue;

			this.Appearing += (sender, args) =>
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

