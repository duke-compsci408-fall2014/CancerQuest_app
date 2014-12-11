using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class TutorialPage : ContentPage 
    {
        public TutorialPage()
        {
            var mainHeader = new HeaderElement("Using MyQ");

            var tutorialImage = new Image
            {
                Source = "tutorial.png",
                //WidthRequest = 60,
                //HeightRequest = 60
            };

            var navigationHeader = new HeaderElement("Navigation");

            var navigationImage = new Image
            {
                Source = "navigation.png"
            };

            var navigationText = new Label
            {
                Text = "The menu button allows you to quickly switch between different pages. On Windows Phones, the menu button is located at the bottom of each page. For iOS and Android, the menu button is at the top of the page.",
                TextColor = Color.FromHex("#636363")
            };

            var addQuestionHeader = new HeaderElement("Adding Questions");

            var addQuestionImage = new Image
            {
                Source = "add_question.png"
            };

            var addQuestionText = new Label
            {
                Text = "Add question to your library by tapping and confirming",
                TextColor = Color.FromHex("#636363")
            };

            var contentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { mainHeader, tutorialImage, navigationHeader, navigationImage, navigationText, addQuestionHeader, addQuestionImage, addQuestionText },
                Spacing = 20,
                Padding = new Thickness(20, 20, 20, 20),
                BackgroundColor = Color.FromHex("#FFFFFF")
            };

            this.Content = new ScrollView
            {
                Content = contentLayout
            };
        }
    }
}
