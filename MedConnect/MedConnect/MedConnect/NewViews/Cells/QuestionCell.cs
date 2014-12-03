using MedConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class QuestionCell : ViewCell
    {
        Question myQuestion;

        public QuestionCell()
        {
            myQuestion = (Question)this.BindingContext;
            
            var textLabel = new Label
            {
                TextColor = Color.FromHex("#636363"),
                Font = Font.SystemFontOfSize(20, FontAttributes.Bold)
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
                Source = "icon_plus.png",
                WidthRequest = 60,
                HeightRequest = 60
            };

            var textLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#FFFFFF"),
                WidthRequest = 320,
                Children = { textLabel, ratingLabel, tagsLabel }
            };

            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#FFFFFF"),
                Padding = new Thickness(20, 20, 20, 20),
                Children = { textLayout, image }
            };

            var mainLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 0, 0, 10),
                BackgroundColor = Color.FromHex("#C1C1C1"),
                Children = { viewLayout }
            };
            View = mainLayout; 
        }
    }
}
