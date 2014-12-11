using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MedConnect.NewViews;
using MedConnect.ViewModels; 

namespace MedConnect
{
    public class App
    {
        public static Page GetMainPage()
        {
            //MasterPage mp = new MasterPage(new MainViewModel());
			var loginPage = new LoginPage();
            return loginPage;
        }
    }
}
