using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedConnect.Models; 
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class LibraryPage : ContentPage
    {     
		StackLayout _mainView; 

        public LibraryPage()
        {            
            BackgroundColor = Color.FromHex("#C1C1C1");

			this.BindingContext = App.MasterPage.MainView;

            var listView = new ListView();
            listView.HasUnevenRows = true;
			listView.SetBinding (ListView.ItemsSourceProperty, new Binding ("LibraryQuestions"));
            listView.ItemTemplate = new DataTemplate(typeof(LibraryCell));

            var header = new HeaderElement("My Library");

            var addQuestionButton = new Button
            {
                Text = "Add Question"
            };

            addQuestionButton.Clicked += (sender, args) =>
            {
				var modalPage = new AddQuestionPage();
                Navigation.PushModalAsync(modalPage);
                listView.SelectedItem = null;
            };

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, listView, addQuestionButton }
            };
					
			this.Appearing += LibraryPage_Appearing;
        }

        void LibraryPage_Appearing(object sender, EventArgs e)
        {
            App.MasterPage.MainView.getLibraryQuestions();
			//this.Content = _mainView; 
        }

        
    }
}
