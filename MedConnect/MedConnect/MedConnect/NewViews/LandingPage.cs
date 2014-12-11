using System;
using Xamarin.Forms;
using System.Diagnostics;
using MedConnect.Models; 
using MedConnect.ViewModels; 
using MedConnect.NewViews.Visits;

namespace MedConnect.NewViews
{
    public class LandingPage : ContentPage 
    {
        MasterPage _masterPage;

        /* 
         * The LandingPage is the first page that users see upon logging in.
         * It presents the user with the basic workflow of the app - discovering questions, adding them to a library, creating visits
         * Each LandingCell is a clickable UI item that takes the user to the appropriate page 
         */ 
        public LandingPage(MasterPage masterPage) 
        {
			Title = "Home";
            _masterPage = masterPage; 
            var header = new HeaderElement("Home");
            var discoverEntry = new LandingCell("Discover", "Find new questions", "icon_search.png", "#9ee4e7");
            var libraryEntry = new LandingCell("My Library", "Save questions to your library", "icon_library.png", "#9ee4e7");
            var visitsEntry = new LandingCell("My Visits", "Organize your saved questions", "icon_calendar.png", "#9ee4e7");

            var discoverTapRecognizer = new TapGestureRecognizer();
            discoverTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage recommendedPage = new RecommendedPage(_masterPage);
				_masterPage.setDetailPage(recommendedPage); 
            };
            discoverEntry.GestureRecognizers.Add(discoverTapRecognizer);

            var libraryTapRecognizer = new TapGestureRecognizer();
            libraryTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage libraryPage = new LibraryPage(_masterPage);
				_masterPage.setDetailPage(libraryPage); 
            };
            libraryEntry.GestureRecognizers.Add(libraryTapRecognizer);

            var visitsTapRecognizer = new TapGestureRecognizer();
            visitsTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage visitsPage = new VisitsPage(_masterPage);
				_masterPage.setDetailPage(visitsPage); 
            };
            visitsEntry.GestureRecognizers.Add(visitsTapRecognizer);

            var contentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, discoverEntry, libraryEntry, visitsEntry }, 
                Spacing = 20,
                Padding = new Thickness(20, 20, 20, 20), 
                BackgroundColor = Color.FromHex("#FFFFFF")
            };

            this.Content = new ScrollView
            {
                Content = contentLayout
            };
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {

        }
    }
}
