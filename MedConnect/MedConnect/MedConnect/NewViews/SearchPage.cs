using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedConnect.Models;
using MedConnect.ViewModels;
using Xamarin.Forms;

namespace MedConnect.NewViews
{
    /* 
     * The SearchPage 
     */
    public class SearchPage : BaseContentPage
    {
		private ListView _listView; 
		private ScrollView _scrollView;

        public SearchViewModel ViewModel
        {
            get { return BindingContext as SearchViewModel; }
            set { }
        }

        public SearchPage()
        {
			Title = "Search";
            BindingContext = App.Model.SearchViewModel;

            BackgroundColor = Color.FromHex("#C1C1C1");
            var header = new HeaderElement("Search");
            
            _listView = new ListView();
            _listView.HasUnevenRows = true;
            _listView.SetBinding(ListView.ItemsSourceProperty, new Binding("Results"));
            _listView.ItemTemplate = new DataTemplate(typeof(QuestionCell));
            _listView.ItemTapped += (sender, args) =>
            {
                var question = args.Item as Question;
                if (question == null) return;
                HandleAddLibrary(question.ID);
                _listView.SelectedItem = null;
            };

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search for questions",
            };

			_scrollView = new ScrollView ();
            _scrollView.Content = new StackLayout { Children = { CreateLoadingIndicator(), _listView } };

            searchBar.SearchButtonPressed += (sender, args) =>
            {
                string searchQuery = searchBar.Text;
                System.Diagnostics.Debug.WriteLine(searchQuery);
                HandleSearch(searchQuery, _listView);
            };

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
				Children = { header, new TabsHeader(), searchBar, _scrollView } 
            };
        }

        public async void HandleSearch(string searchQuery, ListView listview)
        {
            ViewModel.IsLoading = true;
            await App.Model.SearchViewModel.getSearchResults(searchQuery);
            ViewModel.IsLoading = false;
        }
        public async void HandleAddLibrary(int questionID)
        {
            App.MasterPage.MainView.postLibrary(questionID);
            await DisplayAlert("Question Added", "Question added to your library!", "OK");
        }
    }
}
