using System;
using MedConnect.Models;
using MedConnect.Utilies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PortableRest;


namespace MedConnect
{
	public class VisitsViewModel : ViewModel
	{
		private WebService _webService;

		private ObservableCollection<Visit> _visits;

		public ObservableCollection<Visit> Visits
		{
			get{
				return _visits;
			}
			set{
				_visits = value;
				OnPropertyChanged ("Visits");
			}
		}
		private ObservableCollection<Question> _visitQuestions;

		public ObservableCollection<Question> VisitQuestions
		{
			get{
				return _visitQuestions;
			}
			set{
				_visitQuestions = value;
				OnPropertyChanged ("VisitQuestions");
			}
		}


		public VisitsViewModel (WebService webservice)
		{
			_webService = webservice;
			_visits = new ObservableCollection<Visit>();
            _visitQuestions = new ObservableCollection<Question>();
		}

		public async void getVisits(int userID)
		{
			Visits.Clear();
			var tempQ = await _webService.getVisits(userID);
			Visits = tempQ;
			foreach (var q in Visits) {
				//RecommendedQuestions.Add (q);
                //if(q.name.Equals("")) q.name = "Test Lol";
				System.Diagnostics.Debug.WriteLine(q.name);
			}
		}

		public async void createVisit(int userID, string visitName)
		{
			await _webService.createVisit (userID, visitName);
		}

		public async void addVisitQuestion(int userID, int questionID, int visitID)
		{
			await _webService.addQuestionVisit (userID, questionID, visitID);
		}
		public async void getVisitQuestions(int userID, int visitID)
		{
			//webservice call to get visit questions
            VisitQuestions.Clear();
			var tmp = await _webService.getVisitQuestions (userID, visitID);
			VisitQuestions = tmp.Questions;
			_webService.addQuestionInfo (VisitQuestions);
		}
        public void removeVisitQuestion(int userID, int visitID, int questionID)
        {
            _webService.deleteQuestionVisit(userID, questionID, visitID);
        }
        public void deleteVisit(int userID, int visitID)
        {
            _webService.deleteVisit(userID, visitID);
        }
	}
}

