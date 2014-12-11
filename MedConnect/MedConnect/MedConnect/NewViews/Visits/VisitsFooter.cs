using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 
using MedConnect.Models;

namespace MedConnect.NewViews.Visits
{
    public class VisitsFooter : StackLayout
    {
        private Visit _visit;        
        public VisitsFooter(Visit visit)
        {
            _visit = visit;
            var deleteLabel = new Label
            {
                Text = "Delete",
                TextColor = Color.FromHex("#FFFFFF"),
                BackgroundColor = Color.FromHex("#C65B5B")
            };

            var deleteTab = new StackLayout
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.FromHex("#C65B5B"),
                Children = { deleteLabel }
            };

            var deleteTapRecognizer = new TapGestureRecognizer();
            deleteTapRecognizer.Tapped += (s, e) =>
            {
                App.MasterPage.MainView._visitsViewModel.deleteVisit(App.MasterPage.MainView.User.id, _visit.id);

                Navigation.PushModalAsync(new VisitsPage());
            };
            deleteTab.GestureRecognizers.Add(deleteTapRecognizer);

            var renameLabel = new Label
            {
                Text = "Rename",
                TextColor = Color.FromHex("#FFFFFF"),
                BackgroundColor = Color.FromHex("#006166"),
            };

            var renameTab = new StackLayout
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.FromHex("#006166"),
                Children = { renameLabel }
            };

            var renameTapRecognizer = new TapGestureRecognizer();
            renameTapRecognizer.Tapped += (s, e) =>
            {
				var modalPage = new RenameVisitPage();
				Navigation.PushModalAsync(modalPage);
            };
            renameTab.GestureRecognizers.Add(renameTapRecognizer);

            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.StartAndExpand;
            Children.Add(renameTab);
            Children.Add(deleteTab);
        }
    }
}
