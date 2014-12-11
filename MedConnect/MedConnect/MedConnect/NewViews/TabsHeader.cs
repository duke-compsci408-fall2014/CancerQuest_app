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
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new RecommendedPage(_masterPage);
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
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new BrowsePage(_masterPage);
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
                _masterPage.Master = _masterPage.getMasterContentPage();
                _masterPage.Detail = new SearchPage(_masterPage);
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
