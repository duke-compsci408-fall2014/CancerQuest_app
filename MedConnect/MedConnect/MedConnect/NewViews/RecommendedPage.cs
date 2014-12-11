using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.Models; 
using MedConnect.ViewModels; 

namespace MedConnect.NewViews
{
    /*
     * The RecommendPage contains questions drawn from the database that are recommended for the specific user
     * Questions are selected from the DB based on the user's profile (gender, cancer type, age range, etc.) 
     */
    public class RecommendedPage : ContentPage 
    {
        
        public RecommendedPage()
        {            
            Title = "Recommended";
            BackgroundColor = Color.FromHex("#C1C1C1");
            var tabs = new TabsHeader();
            
			App.MasterPage.MainView.getRecQuestions();	

			this.BindingContext = App.MasterPage.MainView;

            var listView = new ListView(); 	 
            listView.HasUnevenRows = true;
			listView.SetBinding (ListView.ItemsSourceProperty, new Binding ("RecommendedQuestions"));
            listView.ItemTemplate = new DataTemplate(typeof(QuestionCell));
            listView.ItemTapped += (sender, args) =>
            {
                var question = args.Item as Question;
                if (question == null) return;
				HandleAddLibrary(question.ID);
                listView.SelectedItem = null;
            };

            var header = new HeaderElement("Recommended Questions");

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, tabs, listView }
            };
            
        }

		public async void HandleAddLibrary(int questionID)
		{
			App.MasterPage.MainView.postLibrary(questionID);
			await DisplayAlert("Question Added", "Question added to your library!", "OK");
		}
    }
}
