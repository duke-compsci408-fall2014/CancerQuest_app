﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.ViewModels;

namespace MedConnect.NewViews
{
    public class AddQuestionPage : ContentPage
    {
        MainViewModel _mainViewModel; 

        public AddQuestionPage(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

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
                _mainViewModel.postQuestion(questionText);
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
    }
}