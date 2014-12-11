using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class BrowsePage : ContentPage 
    {
        MasterPage _masterPage; 

        /* 
         * The BrowsePage allows users to look at different lists of questions.
         * Lists include Most Popular, Most Helpful, and Recently Added 
         * Each list is encapsulated as a LandingCell that takes the user to a separate page 
         */
        public BrowsePage(MasterPage masterPage)
        {
			Title = "Browse";
            _masterPage = masterPage;
            var header = new HeaderElement("Browse");
            var tabs = new TabsHeader(_masterPage);

            var mostPopularEntry = new LandingCell("Most Popular", "Find new questions", "icon_heart.png", "#9ee4e7");
            var mostHelpfulEntry = new LandingCell("Most Helpful", "Save questions to your library", "icon_brightness.png", "#9ee4e7");
            var recentlyAddedEntry = new LandingCell("Recently Added", "Organize your saved questions", "icon_upload.png", "#9ee4e7");

            var mostPopularTapRecognizer = new TapGestureRecognizer();
            mostPopularTapRecognizer.Tapped += (s, e) =>
            {
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new MostPopularPage(_masterPage);
            };
            mostPopularEntry.GestureRecognizers.Add(mostPopularTapRecognizer);

            var mostHelpfulTapRecognizer = new TapGestureRecognizer();
            mostHelpfulTapRecognizer.Tapped += (s, e) =>
            {
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new MostHelpfulPage(_masterPage);
            };
            mostHelpfulEntry.GestureRecognizers.Add(mostHelpfulTapRecognizer);

            var recentlyAddedTapRecognizer = new TapGestureRecognizer();
            recentlyAddedTapRecognizer.Tapped += (s, e) =>
            {
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new RecentlyAddedPage(_masterPage);
            };
            recentlyAddedEntry.GestureRecognizers.Add(recentlyAddedTapRecognizer);

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, tabs, mostPopularEntry, mostHelpfulEntry, recentlyAddedEntry },
                Spacing = 20,
                Padding = new Thickness(20, 20, 20, 20),
                BackgroundColor = Color.FromHex("#FFFFFF")
            };
        }
    }
}
