using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.Models; 
using MedConnect.NewViews.Visits;

namespace MedConnect.NewViews
{
    public class VisitQuestionsPage : ContentPage 
    {        
		private Visit _visit;

		public VisitQuestionsPage(Visit visit)
        {
            this.Appearing += visitQuestionsPage_Appearing;
			_visit = visit;
            BackgroundColor = Color.FromHex("#C1C1C1");
			this.BindingContext = App.MasterPage.MainView._visitsViewModel;

            var listView = new ListView();
            listView.HasUnevenRows = true;
            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("VisitQuestions"));
            listView.ItemTemplate = new DataTemplate(typeof(QuestionCell));
            listView.ItemTapped += (sender, args) =>
            {
                var question = args.Item as Question;
                if (question == null) return;

                var modalPage = new EditVisitQuestionPage(question.ID, _visit.id);
                Navigation.PushModalAsync(modalPage);
                listView.SelectedItem = null;
            };
			var header = new HeaderElement(_visit.name);

            var addQuestionButton = new Button
            {
                Text = "Add Question"
            };

            var footer = new VisitsFooter(_visit); 

            addQuestionButton.Clicked += (sender, args) =>
            {
				var modalPage = new AddVisitQuestion(_visit);
                Navigation.PushModalAsync(modalPage);
                listView.SelectedItem = null;
            };

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, listView, addQuestionButton, footer }
            };
        }

        void visitQuestionsPage_Appearing(object sender, EventArgs e)
        {
            App.MasterPage.MainView._visitsViewModel.getVisitQuestions(App.MasterPage.MainView.User.id, _visit.id);
        }

    }
}
