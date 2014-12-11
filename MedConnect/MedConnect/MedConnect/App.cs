using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MedConnect.NewViews;
using MedConnect.ViewModels; 
using MedConnect.Models; 

namespace MedConnect
{
    public class App
    {
		public static User User {get; set;}

		public static MainViewModel Model { get; set; }

		public static MasterPage MasterPage { get; set; }

        public static Page GetMainPage()
        {
<<<<<<< HEAD
			Model = new MainViewModel ();
			// load user from db

			return new RootPage ();
=======
            //MasterPage mp = new MasterPage(new MainViewModel());
			var loginPage = new LoginPage();
            return loginPage;
>>>>>>> c83f9ed56d5c6fa5def6a4a841a97a4322bb601c
        }
    }
}
