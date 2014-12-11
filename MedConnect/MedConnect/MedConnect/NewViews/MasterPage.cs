using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.Models;
using MedConnect.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using MedConnect.NewViews.Visits;

namespace MedConnect.NewViews
{
    /*
     * The MasterPage allows for users to navigate between the different views through the main menu button 
     * The MasterPage controls the navigation of pages; each page that is displayed on screen is a DetailPage 
     * The MasterPage must hold an instance of the MainViewModel to pass to the detail pages 
     */
    public class MasterPage : MasterDetailPage
    {
		public MainViewModel MainView {
			get {
				return App.Model;
			}
			set {
				App.Model = value;
				OnPropertyChanged("MainView");
			}
		}

        public MasterPage()
        {            
			this.Master = this.getMasterContentPage ();
			this.Detail = new LandingPage ();
        }


        public ContentPage getMasterContentPage()
        {

            var aboutPageButton = new Button
            {
                Text = "About"
            };

            var homePageButton = new Button
            {
                Text = "Home"
            };

            var discoverPageButton = new Button
            {
                Text = "Discover"
            };

            var libraryPageButton = new Button
            {
                Text = "My Library"
            };

            var visitsPageButton = new Button
            {
                Text = "My Visits"
            };

            var settingsPageButton = new Button
            {
                Text = "My Settings"
            };

            var helpPageButton = new Button
            {
                Text = "Help"
            };

            var logoutButton = new Button
            {
                Text = "Logout"
            };

            var master = new ContentPage
            {
                Title = "Menu",
                BackgroundColor = Color.Silver,
                Content = new StackLayout
                {
                    Padding = new Thickness(5, 50),
                    Children = { homePageButton, aboutPageButton, discoverPageButton, libraryPageButton, visitsPageButton, settingsPageButton, helpPageButton, logoutButton }
                }
            };

            homePageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new LandingPage());
                IsPresented = false;
            };

            aboutPageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new AboutPage());
                IsPresented = false;
            };

            discoverPageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new RecommendedPage());
                IsPresented = false;
            };

            libraryPageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new LibraryPage());
                IsPresented = false;
            };

            visitsPageButton.Clicked += (sender, args) =>
            {
				Detail = new NavigationPage(new VisitsPage());
                IsPresented = false;
            };

            settingsPageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new SettingsPage());
                IsPresented = false; 
            };

            helpPageButton.Clicked += (sender, args) =>
            {
                Detail = new NavigationPage(new TutorialPage());
                IsPresented = false; 
            };

            logoutButton.Clicked += (sender, args) =>
            {
				Navigation.PushModalAsync(new LoginPage());
                IsPresented = false; 
            };

            return master; 
        }

		public void setDetailPage(ContentPage page) 
		{
			Detail = new NavigationPage (page); 
			IsPresented = false; 
		}
    }
}
