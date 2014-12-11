using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedConnect.ViewModels; 

namespace MedConnect.NewViews
{
    /*
     * The LoginPage allows users to login to the app if they already have an account
     * If not, users can use the page to access the SignupPage, which is used to create a new account 
     */
    public class LoginPage : ContentPage 
    {
        MainViewModel _mainViewModel; 
		MasterPage mp;

        private StackLayout loginForm;
        private StackLayout loginView;

        public LoginPage()
        {
            _mainViewModel = new MainViewModel();
            mp = new MasterPage(_mainViewModel);

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

            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                BackgroundColor = Color.FromHex("C1C1C1"),
                VerticalOptions = LayoutOptions.Center, 
                IsPassword = true
            };

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

			loginForm = new StackLayout {
				Children = { usernameEntry, passwordEntry, loginButton, signupButton }
			};

			Content = new ScrollView {
				Content = new StackLayout
	            {
	                Children = { image, loginForm },
	                Padding = new Thickness(40, 40, 40, 20),
	                Spacing = 20,
	                BackgroundColor = Color.FromHex("#FFFFFF")
	            }
			};

            loginView = (StackLayout)((ScrollView)Content).Content;

            loginButton.Clicked += (sender, args) =>
            {
                setLoginForm(
                    new ActivityIndicator
                    {
                        IsRunning = true
                    }
                );
                string username = usernameEntry.Text;
                string password = passwordEntry.Text; 
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
					setLoginForm();
                    DisplayAlert("Error", "Invalid username or password", "OK");
                }
                else
                {
                    HandleLogin(username, password);
                }
            };

            signupButton.Clicked += (sender, args) =>
            {
				Navigation.PushAsync(new SignupPage(mp));
            };
        }

        private void setLoginForm(View view = null)
        {
            if (view == null)
            {
                view = loginForm;
            }
            loginView.Children[1] = view;
        }

		private async void HandleLogin(String username, String password) 
        {
			mp.Master = mp.getMasterContentPage();
			mp.Detail = new LandingPage(mp);
			await mp.MainView.authenticate(username,password);
			if(mp.MainView.User != null) {
				//System.Diagnostics.Debug.WriteLine (mp.MainView.User);
				await Navigation.PushModalAsync(mp);
				mp.MainView.getLibraryQuestions ();
                setLoginForm();
			}
            else
            {
                setLoginForm();
				//System.Diagnostics.Debug.WriteLine ("fag muffin to the rescue");
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
		}
    }
}
