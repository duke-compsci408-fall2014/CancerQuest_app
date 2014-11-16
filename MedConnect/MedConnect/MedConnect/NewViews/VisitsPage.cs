﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedConnect.Models; 
using Xamarin.Forms;

namespace MedConnect.NewViews
{
    public class VisitsPage : ContentPage
    {
		private MasterPage _masterPage;
		public VisitsPage(MasterPage masterPage)
        {
			_masterPage = masterPage;

            BackgroundColor = Color.FromHex("#C1C1C1");
            ObservableCollection<Visit> Questions = new ObservableCollection<Visit>();
            Visit q1 = new Visit
            {
                name = "This is a sample question",

            };
			Visit q2 = new Visit
			{
				name = "This is a sample question",

			};
            
            Questions.Add(q1);
            Questions.Add(q2);

			_masterPage.MainView.getVisits();

			this.BindingContext = _masterPage.MainView._visitsViewModel;

            var listView = new ListView();
            listView.HasUnevenRows = true;
			listView.SetBinding (ListView.ItemsSourceProperty, new Binding ("Visits"));
			//listView.ItemsSource = Questions;
            listView.ItemTemplate = new DataTemplate(typeof(VisitCell));

            var header = new HeaderElement("My Visits");
            var addVisitsButton = new Button
            {
                Text = "Add New Visit"
            };
            addVisitsButton.Clicked += (sender, args) =>
            {

            };

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, listView, addVisitsButton}
            };
        }
    }
}
