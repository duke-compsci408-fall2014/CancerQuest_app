using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.ViewModels;
using MedConnect.Utilities; 

namespace MedConnect.NewViews
{
    /*
     * The LoginPage allows users to login to the app if they already have an account
     * If not, users can use the page to access the SignupPage, which is used to create a new account 
     */
	public class LoginPage : BaseContentPage 
    {
		public LoginViewModel ViewModel {
			get { return BindingContext as LoginViewModel; }
			set { }
		}
        public LoginPage()
        {
			BindingContext = new LoginViewModel();

            var image = new Image
            {
                Source = ImageSource.FromFile("logo3.png"),
                WidthRequest = 200,
                HeightRequest = 200
            };

            var usernameEntry = new Entry
            {
                Placeholder = "Username",
                BackgroundColor = Color.FromHex("C1C1C1"),
                VerticalOptions = LayoutOptions.Center, 
            };
			usernameEntry.SetBinding (Entry.TextProperty, "Username", BindingMode.TwoWay);

            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                BackgroundColor = Color.FromHex("C1C1C1"),
                VerticalOptions = LayoutOptions.Center, 
                IsPassword = true
            };
			passwordEntry.SetBinding (Entry.TextProperty, "Password", BindingMode.TwoWay);

            var loginButton = new Button
            {
                Text = "Login",
				TextColor = Color.FromHex("#FFFFFF"),
                BackgroundColor = Color.FromHex("#9ee4e7")
            };

            var signupButton = new Button
            {
                Text = "Sign up",
				TextColor = Color.FromHex("#FFFFFF"),
                BackgroundColor = Color.FromHex("#76ccd0")
            };

			var loginForm = new StackLayout {
				Children = { usernameEntry, passwordEntry, loginButton, signupButton }
			};

			var content = new ScrollView {
				Content = new StackLayout
	            {
	                Children = { image, loginForm },
	                Padding = new Thickness(40, 40, 40, 20),
	                Spacing = 20,
	                BackgroundColor = Color.FromHex("#FFFFFF")
	            }
			};
			Content = content;
			//Content = CreateLoadingIndicatorAbsoluteLayout (content);

            loginButton.Clicked += (sender, args) =>
            {
				if (ViewModel.IsLoading) {
					return;
				}
				ViewModel.IsLoading = true;
                string username = usernameEntry.Text;
                string password = passwordEntry.Text; 
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    DisplayAlert("Error", "Please enter your username and password", "OK");
                }
                else
                {
                    HandleLogin(username, password);
                }
            };

            signupButton.Clicked += (sender, args) =>
            {
				Navigation.PushAsync(new SignupPage());
            };
        }

		private async void HandleLogin(String username, String password) 
        {
			var result = await App.Model.authenticate(username,password);
			ViewModel.IsLoading = false;

			if(result != null) {
				App.Model.getLibraryQuestions ();               
				await Navigation.PopModalAsync();
			}
            else
            {                
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
		}
    }
}
