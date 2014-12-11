﻿using System;
using Xamarin.Forms; 
using MedConnect.ViewModels; 

namespace MedConnect.NewViews
{
	public class AddVisitPage : ContentPage 
	{
		MasterPage _masterPage; 

		public AddVisitPage (MasterPage masterPage)
		{
			_masterPage = masterPage; 

			var header = new HeaderElement ("Add New Visit"); 

			var visitNameEntry = new Entry
			{
				Text = "Name your visit"
			};

			var submitQuestionButton = new Button
			{
				Text = "Create new visit"
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
				string visitName = visitNameEntry.Text;
				HandleAddVisit(visitName);
				Navigation.PopModalAsync();
			};

			var mainLayout = new StackLayout
			{
				Padding = new Thickness(50, 50, 50, 50),
				BackgroundColor = Color.FromRgba(1, 1, 1, 0.5),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = { header, visitNameEntry, submitQuestionButton, cancelButton }
			};

			Content = mainLayout;
		}

		public async void HandleAddVisit(string visitName)
		{
			int userID = _masterPage.MainView.User.id;
			_masterPage.MainView._visitsViewModel.createVisit (userID, visitName);
			await DisplayAlert("Visit Created", "New Visit created!", "OK");
		}
	}
}

