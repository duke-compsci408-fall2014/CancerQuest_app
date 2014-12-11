using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class TabsHeader : StackLayout
    {
        MasterPage _masterPage;

        public TabsHeader(MasterPage masterPage)
        {
            _masterPage = masterPage; 

            var recommendedLabel = new Label
            {
                Text = "Recommended",
                TextColor = Color.FromHex("#636363"),
                BackgroundColor = Color.FromHex("#76ccd0"),
                //Font = Font.SystemFontOfSize(NamedSize.Medium)
            };

            var recommendedTab = new StackLayout
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.FromHex("#76ccd0"),
                Children = { recommendedLabel }
            };

            var recommendedTapRecognizer = new TapGestureRecognizer();
            recommendedTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage recommended = new RecommendedPage(_masterPage);
				_masterPage.setDetailPage(recommended); 
            };
            recommendedTab.GestureRecognizers.Add(recommendedTapRecognizer);

            var browseLabel = new Label
            {
                Text = "Browse",
                TextColor = Color.FromHex("#636363"),
                BackgroundColor = Color.FromHex("#76ccd0")
            };

            var browseTab = new StackLayout
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.FromHex("#76ccd0"),
                Children = { browseLabel }
            };

            var browseTapRecognizer = new TapGestureRecognizer();
            browseTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage browsePage = new BrowsePage(_masterPage);
				_masterPage.setDetailPage(browsePage); 
            };
            browseTab.GestureRecognizers.Add(browseTapRecognizer);

            var searchLabel = new Label
            {
                Text = "Search",
                TextColor = Color.FromHex("#636363"),
                BackgroundColor = Color.FromHex("##76ccd0"),
            };

            var searchTab = new StackLayout
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.FromHex("#76ccd0"),
                Children = { searchLabel }
            };

            var searchTapRecognizer = new TapGestureRecognizer();
            searchTapRecognizer.Tapped += (s, e) =>
            {
				ContentPage searchPage = new SearchPage(_masterPage);
				_masterPage.setDetailPage(searchPage); 
            };
            searchTab.GestureRecognizers.Add(searchTapRecognizer);

			if (Device.OS == TargetPlatform.iOS) {
				recommendedLabel.Font = Font.SystemFontOfSize (NamedSize.Micro); 
				browseLabel.Font = Font.SystemFontOfSize (NamedSize.Micro); 
				searchLabel.Font = Font.SystemFontOfSize (NamedSize.Micro); 
			}
            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.StartAndExpand; 
            Children.Add(recommendedTab);
            Children.Add(browseTab);
            Children.Add(searchTab);

        }
    }
}
