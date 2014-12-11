using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 
using MedConnect.Models;

namespace MedConnect.NewViews
{
    public class LibraryCell : ViewCell
    {
        public LibraryCell()
        {
			var textLabel = new Label
			{
				TextColor = Color.FromHex("#636363")
			};
			textLabel.SetBinding(Label.TextProperty, "Text");

			var ratingLabel = new Label
			{
				TextColor = Color.FromHex("#636363"),
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};
			ratingLabel.SetBinding(Label.TextProperty, "RatingText");

			var tagsLabel = new Label
			{
				TextColor = Color.FromHex("#636363"),
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};
			tagsLabel.SetBinding(Label.TextProperty, "TagInfo");

			var image = new Image
			{
				Source = "icon_compose.png",
				WidthRequest = 60,
				HeightRequest = 60
			};

			var editQuestionTapRecognizer = new TapGestureRecognizer();
			editQuestionTapRecognizer.Tapped += (s, e) =>
			{
				var question = BindingContext as Question;
				App.MasterPage.Detail.Navigation.PushModalAsync(new EditQuestionPage(App.MasterPage, question.ID));
			};
			image.GestureRecognizers.Add(editQuestionTapRecognizer);

			var textLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.FromHex("#FFFFFF"),
				Children = { textLabel, ratingLabel, tagsLabel }
			};

			//Platform-specific formatting 
			if (Device.OS == TargetPlatform.iOS) {
				textLabel.Font = Font.SystemFontOfSize (10, FontAttributes.Bold);
				textLayout.WidthRequest = 600; 
				ratingLabel.Font = Font.SystemFontOfSize (10, FontAttributes.None);
				tagsLabel.Font = Font.SystemFontOfSize (10, FontAttributes.None);
			} else {
				textLabel.Font = Font.SystemFontOfSize (20, FontAttributes.Bold);
				textLayout.WidthRequest = 320; 
			}

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.FromHex("#FFFFFF"),
				Padding = new Thickness(20, 20, 20, 20),
				Children = { textLayout, image }
			};

			if (Device.OS == TargetPlatform.iOS) {
				viewLayout.Padding = new Thickness (10, 5, 5, 5);
			}

			var mainLayout = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Start,
				Padding = new Thickness(0, 0, 0, 10),
				BackgroundColor = Color.FromHex("#C1C1C1"),
				Children = { viewLayout }
			};

			if (Device.OS == TargetPlatform.iOS) {
				mainLayout.Padding = new Thickness (0, 0, 0, 0); 
			}

			View = mainLayout; 
		}
    }
}
