using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    /*
     * The AboutPage presents an overview of the app, including its intended purpose and basic functionality
     */
    public class AboutPage : ContentPage 
    {
        public AboutPage()
        {
            /* Create a header for the page */
            var header = new HeaderElement("About");

            /* Create a label to describe the app functionality */
            var descriptionLabel = new Label
            {
                Text = "The MyQ application empowers cancer patients to find the best questions to bring to their physicians. It is difficult enough to be diagnosed with cancer: MyQ helps patients figure out what questions they want to ask while they deal with the stress and shock of a cancer diagnosis. Patients can either browse questions that are specially tailored to their backgrounds and cancer type, or they can browse lists of user-generated, crowd-sourced questions.",
                TextColor = Color.FromHex("#636363")
            };

            /* Put contents of page into new stack layout */
            var contentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, descriptionLabel },
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
