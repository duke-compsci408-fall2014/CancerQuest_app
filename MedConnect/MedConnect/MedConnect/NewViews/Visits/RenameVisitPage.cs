using System;
using Xamarin.Forms; 

namespace MedConnect.NewViews.Visits
{
	public class RenameVisitPage : ContentPage 
	{
		MasterPage _masterPage; 

		public RenameVisitPage (MasterPage masterPage)
		{
			_masterPage = masterPage; 

			var header = new HeaderElement ("Rename Visit"); 

			var renameVisitEntry = new Entry
			{
				Text = "Rename your visit"
			};

			var submitNewNameButton = new Button
			{
				Text = "Submit new name"
			};

			var cancelButton = new Button
			{
				Text = "Cancel"
			};

			cancelButton.Clicked += (sender, args) =>
			{
				Navigation.PopModalAsync();
			};

			submitNewNameButton.Clicked += (sender, args) =>
			{
				string visitName = renameVisitEntry.Text;
				Navigation.PopModalAsync();
			};

			var mainLayout = new StackLayout
			{
				Padding = new Thickness(50, 50, 50, 50),
				BackgroundColor = Color.FromRgba(1, 1, 1, 0.5),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = { header, renameVisitEntry, submitNewNameButton, cancelButton }
			};

			Content = mainLayout;
		}
	}
}

