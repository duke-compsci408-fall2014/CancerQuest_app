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
        MasterPage _masterPage; 
		private ListView _listView; 
		private ScrollView _scrollView;

        public SearchPage(MasterPage masterPage)
        {
			Title = "Search";
            _masterPage = masterPage; 

            BackgroundColor = Color.FromHex("#C1C1C1");
            var header = new HeaderElement("Search");
            _listView = new ListView();
			_listView.IsVisible = false; 

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search for questions",
            };

			_scrollView = new ScrollView (); 

            searchBar.SearchButtonPressed += (sender, args) =>
            {
                string searchQuery = searchBar.Text;
                System.Diagnostics.Debug.WriteLine(searchQuery);
				_scrollView.Content = new ActivityIndicator {
					IsRunning = true
				}; 
                HandleSearch(searchQuery, _listView);
            };

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
				Children = { header, new TabsHeader(_masterPage), searchBar, _scrollView } 
            };
        }

        public void HandleSearch(string searchQuery, ListView listview)
        {
            _masterPage.MainView._searchViewModel.getSearchResults(searchQuery);
            this.BindingContext = _masterPage.MainView._searchViewModel;
            listview.HasUnevenRows = true;
            listview.SetBinding(ListView.ItemsSourceProperty, new Binding("Results"));
            listview.ItemTemplate = new DataTemplate(typeof(QuestionCell));
			_scrollView.Content = listview;
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
            _masterPage.MainView.postLibrary(questionID);
            await DisplayAlert("Question Added", "Question added to your library!", "OK");
        }
    }
}
