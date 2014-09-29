﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.ViewModels; 

namespace MedConnect.Views
{
    class LoginPage : ContentPage
    {
        public LoginPage() 
        {
            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
               {
                   new TableSection
                   {
                       new EntryCell
                       {
                           Label = "Username"
                       },
                       new EntryCell
                       {
                           Label = "Password"
                       }
                   }
               }
            };

            var submitButton = new Button
            {
                Text = "Submit"
            };

            this.Padding = new Thickness(50);

            this.Content = new StackLayout
            {
                Children = { tableView, submitButton }
            };
        }
    }
}