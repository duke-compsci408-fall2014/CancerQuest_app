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
    public class SignupPage : ContentPage
    {

		public SignupPage()
        {
            var header = new HeaderElement("Sign Up");

            var usernameEntry = new Entry
            {
                Placeholder = "Select a username",
                BackgroundColor = Color.FromHex("#9ee4e7")
            };

            var passwordEntry = new Entry
            {
                Placeholder = "Select a password",
                BackgroundColor = Color.FromHex("#9ee4e7"),
                IsPassword = true
            };

            var passwordRetypeEntry = new Entry
            {
                Placeholder = "Retype your password",
                BackgroundColor = Color.FromHex("#9ee4e7"),
                IsPassword = true
            };

			var emailEntry = new Entry
			{
				Placeholder = "Type in your email",
				BackgroundColor = Color.FromHex("#9ee4e7"),
				
			};

            List<String> genderTypes = new List<String>
            {
                "Male",
                "Female",
                "Other"
            };

            var genderLabel = new Label
            {
                Text = "Choose your gender",
                TextColor = Color.FromHex("#C1C1C1")
            };

            var genderPicker = new Picker
            {
                Title = "Choose Your Gender",
                BackgroundColor = Color.FromHex("#C1C1C1"),
                VerticalOptions = LayoutOptions.CenterAndExpand 
            };

            foreach (string genderString in genderTypes)
            {
                genderPicker.Items.Add(genderString);
            }

            List<String> cancerTypes = new List<String>
            {
                "Cancer Type 1",
                "Cancer Type 2",
                "Cancer Type 3"
            };

            var cancerPickerLabel = new Label
            {
                Text = "Choose your cancer type",
                TextColor = Color.FromHex("#C1C1C1")
            };

            var cancerPicker = new Picker
            {
                Title = "Cancer Type",
                BackgroundColor = Color.FromHex("#C1C1C1"),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string cancerString in cancerTypes)
            {
                cancerPicker.Items.Add(cancerString);
            }

            var submitButton = new Button
            {
                Text = "Create an account",
                BackgroundColor = Color.FromHex("#9ee4e7")
            };

			submitButton.Clicked += (sender, args) =>
			{
				string username = usernameEntry.Text;
				string password = passwordEntry.Text; 
				string repassword = passwordRetypeEntry.Text;
				//check password and retype are same!!
				string email = emailEntry.Text;
				if(!(password.Equals(repassword))) {
					DisplayAlert("Error", "Passwords do not match", "OK");
				}
				HandleSignUp(username, password, email);
			};

            var contentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, usernameEntry, passwordEntry, passwordRetypeEntry, emailEntry, genderLabel, genderPicker, cancerPickerLabel, cancerPicker, submitButton },
                //Spacing = 20,
                //Padding = new Thickness(20, 20, 20, 20),
                BackgroundColor = Color.FromHex("#FFFFFF")
            };

			if (Device.OS == TargetPlatform.iOS) {
				Padding = new Thickness (20, 20, 20, 20);
			}

            Content = new ScrollView
            {
                Content = contentLayout 
            }; 
        }

		public async void HandleSignUp(string username, string password, string email)
		{
			var result = await App.MasterPage.MainView.createUser (username, password, email);
			System.Diagnostics.Debug.WriteLine (result.username);
			if (result.username != "null") {
				await DisplayAlert("Success!", "Welcome new user! ", "OK");
			}
		}
    }
}
