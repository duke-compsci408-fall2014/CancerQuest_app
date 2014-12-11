using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedConnect.Models;
using Xamarin.Forms;

namespace MedConnect.NewViews
{
    /* 
     * The SearchPage 
     */
    public class SearchPage : ContentPage
    {
        
        public SearchPage()
        {
			Title = "Search";           

            BackgroundColor = Color.FromHex("#C1C1C1");
            var header = new HeaderElement("Search");
            var listView = new ListView();
            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search for questions",
            };
            searchBar.SearchButtonPressed += (sender, args) =>
            {
                string searchQuery = searchBar.Text;
                System.Diagnostics.Debug.WriteLine(searchQuery);
                HandleSearch(searchQuery, listView);

            };


            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                Children = { header, new TabsHeader(), searchBar, 
                    new ScrollView
                    {
                        Content = listView,
                    }
                }
            };
        }

        public void HandleSearch(string searchQuery, ListView listview)
        {
            App.MasterPage.MainView._searchViewModel.getSearchResults(searchQuery);

            this.BindingContext = App.MasterPage.MainView._searchViewModel;
            listview.HasUnevenRows = true;
            listview.SetBinding(ListView.ItemsSourceProperty, new Binding("Results"));
            listview.ItemTemplate = new DataTemplate(typeof(QuestionCell));

            listview.ItemTapped += (sender, args) =>
            {
                var question = args.Item as Question;
                if (question == null) return;

                HandleAddLibrary(question.ID);

                listview.SelectedItem = null;
            };
        }
        public async void HandleAddLibrary(int questionID)
        {
            App.MasterPage.MainView.postLibrary(questionID);
            await DisplayAlert("Question Added", "Question added to your library!", "OK");

        }
    }
}
