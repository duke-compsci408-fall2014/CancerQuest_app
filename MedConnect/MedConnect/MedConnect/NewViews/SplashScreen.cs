using System;
using Xamarin.Forms;
using MedConnect.NewViews;

namespace MedConnect
{
	public class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
			this.BackgroundColor = Color.White;

			var image = new Image 
			{
				Source = "splash_icon.png",
				WidthRequest = 300,
				HeightRequest = 300
			};

			Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand, 
				Children = { image }
			};

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

