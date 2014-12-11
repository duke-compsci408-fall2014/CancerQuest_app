using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.ViewModels;
using MedConnect.Models;

namespace MedConnect.NewViews
{
    public class AddQuestionPage : ContentPage
    {
        MainViewModel _mainViewModel; 
		Question _postedQuestion;

        public AddQuestionPage(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
			_postedQuestion = new Question ();

            var header = new HeaderElement("Add a Question");

            var questionTextEntry = new Entry
            {
                Text = "Type your question here"
            };

            var submitQuestionButton = new Button
            {
                Text = "Submit question"
            };

            var cancelButton = new Button
            {
                Text = "Cancel"
            };

            cancelButton.Clicked += (sender, args) =>
            {
                Navigation.PopModalAsync();
            };

            submitQuestionButton.Clicked += (sender, args) =>
            {
                string questionText = questionTextEntry.Text;
				HandlePost(questionText);
                Navigation.PopModalAsync();
            };

            var mainLayout = new StackLayout
            {
                Padding = new Thickness(50, 50, 50, 50),
                BackgroundColor = Color.FromRgba(1, 1, 1, 0.5),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { header, questionTextEntry, submitQuestionButton, cancelButton }
            };

            Content = mainLayout;
        }

		public async void HandlePost(string questionText)
		{
			var response = await _mainViewModel.postQuestion(questionText);
			
			_postedQuestion = response;
			System.Diagnostics.Debug.WriteLine(_postedQuestion.Text);
			_mainViewModel.postLibrary(_postedQuestion.ID);
			//on success do this later
			_mainViewModel.LibraryQuestions.Add (_postedQuestion);

		}
    }
}
