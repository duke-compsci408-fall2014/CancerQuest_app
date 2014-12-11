using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class LandingCell : StackLayout 
    {
        public LandingCell(String mainText, String detail, String imageName, String color)
        {
            var image = new Image
            {
                Source = ImageSource.FromFile(imageName),
                WidthRequest = 60,
                HeightRequest = 60
            };

            var mainTextLabel = new Label
            { 
                Text = mainText,
                TextColor = Color.FromHex("#636363"),
                Font = Font.SystemFontOfSize(20, FontAttributes.Bold)
            };

            var detailLabel = new Label
            {
                Text = detail,
                TextColor = Color.FromHex("#636363"),
            };

			//Platform-specific formatting 
			if (Device.OS == TargetPlatform.iOS) {
				detailLabel.Font = Font.SystemFontOfSize (NamedSize.Micro); 
				mainTextLabel.Font = Font.SystemFontOfSize (16, FontAttributes.Bold);
			} else {
				detailLabel.Font = Font.SystemFontOfSize (NamedSize.Medium);
				mainTextLabel.Font = Font.SystemFontOfSize (20, FontAttributes.Bold);
			}

            StackLayout textLayout = new StackLayout
            {
               Orientation = StackOrientation.Vertical,
               Padding = new Thickness(20, 20, 20, 20),
               Children = { mainTextLabel, detailLabel }
            };

            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.FillAndExpand; 
            Children.Add(image);
            Children.Add(textLayout);
            BackgroundColor = Color.FromHex(color);
            Padding = new Thickness(10, 10, 10, 10); 
        }
    }
}
