using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.Models; 

namespace MedConnect.NewViews
{
    public class EditVisitQuestionPage : ContentPage 
    {
		private int _questionID;
        private int _visitID;

		public EditVisitQuestionPage(int questionID, int visitID)
		{
			_questionID = questionID;
            _visitID = visitID;

			var rateQuestionLabel = new Label
			{
				Text = "Was this question helpful?",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var helpfulButton = new Button
			{
				Text = "Yes",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
			};

			var notHelpfulButton = new Button
			{
				Text = "No",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
			};

			var yesNoLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { helpfulButton, notHelpfulButton }
			};

			var removeQuestionButton = new Button
			{
				Text = "Remove question from appointment"
			};

			var cancelButton = new Button
			{
				Text = "Cancel"
			};

            removeQuestionButton.Clicked += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("Question removed");
                int userID = App.MasterPage.MainView.User.id;
                App.MasterPage.MainView._visitsViewModel.removeVisitQuestion(userID,_visitID,_questionID);
                
                Navigation.PopModalAsync();
            };
            cancelButton.Clicked += (sender, args) =>
            {
                Navigation.PopModalAsync();
            };
			helpfulButton.Clicked += (sender, args) =>
			{
				System.Diagnostics.Debug.WriteLine("User voted question helpful");
				App.MasterPage.MainView.rateQuestion(_questionID,"Helpful");
				Navigation.PopModalAsync();
			};

			notHelpfulButton.Clicked += (sender, args) =>
			{
				App.MasterPage.MainView.rateQuestion(_questionID, "Unhelpful");
				Navigation.PopModalAsync();
				System.Diagnostics.Debug.WriteLine("User voted question unhelpful");
			};


            var mainLayout = new StackLayout
            {
                Padding = new Thickness(50, 50, 50, 50),
                BackgroundColor = Color.FromRgba(1, 1, 1, 0.5),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { rateQuestionLabel, yesNoLayout, removeQuestionButton, cancelButton }
            };

            Content = mainLayout;
		}
    }
}
