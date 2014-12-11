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
			Model = new MainViewModel ();
			// load user from db

			return new RootPage ();
        }
    }
}
