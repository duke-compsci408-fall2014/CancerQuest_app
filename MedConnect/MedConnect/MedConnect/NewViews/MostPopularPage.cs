﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.Models; 

namespace MedConnect.NewViews
{
    public class MostPopularPage : ContentPage 
    {
        public MostPopularPage()
        {            
            Title = "Most Popular Questions";
            BackgroundColor = Color.FromHex("#C1C1C1");

            this.BindingContext = App.MasterPage.MainView;

            var listView = new ListView();
            listView.HasUnevenRows = true;
            //listView.SetBinding(ListView.ItemsSourceProperty, new Binding("RecommendedQuestions"));
            listView.ItemTemplate = new DataTemplate(typeof(QuestionCell));
            listView.ItemTapped += (sender, args) =>
            {
                var question = args.Item as Question;
                if (question == null) return;
                listView.SelectedItem = null;
            };

            var header = new HeaderElement("Most Popular Questions");

            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, listView }
            };
        }
    }
}
