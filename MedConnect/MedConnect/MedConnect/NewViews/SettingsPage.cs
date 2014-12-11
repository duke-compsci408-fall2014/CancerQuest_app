using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class SettingsPage : ContentPage 
    {
        MasterPage _masterPage; 

        public SettingsPage(MasterPage masterPage)
        {
            _masterPage = masterPage; 

            var header = new HeaderElement("Settings");

            var passwordEntry = new Entry
            {
                Placeholder = "Change your password",
                BackgroundColor = Color.FromHex("#9ee4e7"),
                IsPassword = true
            };

            var passwordRetypeEntry = new Entry
            {
                Placeholder = "Retype your new password",
                BackgroundColor = Color.FromHex("#9ee4e7"),
                IsPassword = true
            };

            var emailEntry = new Entry
            {
                Placeholder = "Change your email",
                BackgroundColor = Color.FromHex("#9ee4e7"),

            };

            var genderPicker = new Picker
            {
                Title = "Choose Your Gender",
                BackgroundColor = Color.FromHex("#C1C1C1"),
                VerticalOptions = LayoutOptions.CenterAndExpand
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
                Text = "Change your account settings",
                BackgroundColor = Color.FromHex("#9ee4e7")
            };

            submitButton.Clicked += (sender, args) =>
            {

            };

            var contentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, passwordEntry, passwordRetypeEntry, emailEntry, genderLabel, genderPicker, cancerPickerLabel, cancerPicker, submitButton },
                Spacing = 20,
                Padding = new Thickness(20, 20, 20, 20),
                BackgroundColor = Color.FromHex("#FFFFFF")
            };

            Content = contentLayout; 
        }
    }
}
