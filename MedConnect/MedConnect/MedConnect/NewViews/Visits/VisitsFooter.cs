using MedConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews.Visits
{
    public class VisitsFooter : StackLayout
    {
        private Visit _visit;
        private MasterPage _masterPage;
        public VisitsFooter(Visit visit, MasterPage masterPage)
        {
            _visit = visit;
            _masterPage = masterPage;

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
                _masterPage.MainView._visitsViewModel.deleteVisit(_masterPage.MainView.User.id, _visit.id);

                Navigation.PushModalAsync(new VisitsPage(_masterPage));
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
				var modalPage = new RenameVisitPage(_masterPage);
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
