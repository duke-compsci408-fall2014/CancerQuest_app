using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedConnect.Models;

namespace MedConnect.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
		public int id { get; set; }
		public string session {get; set;} 
        public ObservableCollection<Question> Questions { get; set; }
		public ObservableCollection<Visit> Visits { get; set; }

        public User()
        {
            Questions = new ObservableCollection<Question>(); 
			Visits = new ObservableCollection<Visit> ();
        }
    }
}
