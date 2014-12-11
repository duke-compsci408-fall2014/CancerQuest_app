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

namespace MedConnect.ViewModels
{
	public class MainViewModel : ViewModel
	{
		private WebService _webService;
		private static User _currentUser;
		public VisitsViewModel _visitsViewModel;
        public SearchViewModel _searchViewModel;
        public TagTranslator _tagTranslator;

		private ObservableCollection<Question> _recommendedQuestions;

        public ObservableCollection<Question> RecommendedQuestions
        {
            get
            {
                return _recommendedQuestions;
            }
            set
            {
                _recommendedQuestions = value;
				OnPropertyChanged("RecommendedQuestions");
            }
        } 

		public User User
		{
			get
			{
				return _currentUser;
			}
			set
			{
				_currentUser = value;
				OnPropertyChanged("User");
			}
		}
		private ObservableCollection<Question> _libraryQuestions;

		public ObservableCollection<Question> LibraryQuestions
		{
			get
			{
				return _libraryQuestions;
			}
			set
			{
				_libraryQuestions = value;
				OnPropertyChanged ("LibraryQuestions");
			}
		}

        //should we have instances of every view so that we can cache them? or is that stupid and should we make new ones everytime... 

		public MainViewModel () {
			_webService = new WebService();
            _recommendedQuestions = new ObservableCollection<Question>();
			_libraryQuestions = new ObservableCollection<Question>();

			_visitsViewModel = new VisitsViewModel (_webService);
            _searchViewModel = new SearchViewModel (_webService);
			//test createUser
			//createUser ("Kevin", "Test", "jon@jo.

            //_tagTranslator = new TagTranslator(_webService);
            //_searchViewModel.getSearchResults("what");
		    //_webService.getTags();

		}

		public async Task<User> authenticate(string username, string password)
        {
			var responseUser = await _webService.login (username, password);
			//System.Diagnostics.Debug.WriteLine (_currentUser);
			User = responseUser;
			if (User != null) {
				_libraryQuestions = User.Questions; 
			}
			_webService.setSession (User.session);
			getSortedQuestions ("popular");
			return User;
        }

        public async void getRecQuestions()
        {
            RecommendedQuestions.Clear();
            var tempQ = await _webService.getRecQuestions();
            RecommendedQuestions = tempQ;

			_webService.addQuestionInfo (RecommendedQuestions);
        }
		public async void getSortedQuestions(string type)
		{
			RecommendedQuestions.Clear();
			var tempQ = await _webService.getSortedQuestions(type);
			RecommendedQuestions = tempQ;

			_webService.addQuestionInfo (RecommendedQuestions);
		}


		public async void getLibraryQuestions()
		{
			LibraryQuestions.Clear();
			var tempQ = await _webService.getLibraryQuestions(_currentUser.id);
			LibraryQuestions = tempQ;
			_webService.addQuestionInfo (LibraryQuestions);

		}
		public async Task<Question> postQuestion(String s)
        {
            var response = await _webService.postQuestion(s);
			return response;
        }
		public void getVisits()
		{
			_visitsViewModel.getVisits (_currentUser.id);
		}

		public async void postLibrary(int questionID)
		{
			var response = await _webService.postLibrary(questionID, _currentUser.id);
		}
		public async void postVisitQuestion(int userID, int questionID, int visitID)
		{
			await _webService.addQuestionVisit (userID, questionID, visitID);
		}
		public async Task<User> createUser(string username, string password, string email)
		{
			var responseUser = await _webService.createUser (username, password, email);
			//System.Diagnostics.Debug.WriteLine (_currentUser);
			User = responseUser;
			return User;
		}
        public void removeLibraryQuestion(int questionID)
        {
            _webService.removeLibraryQuestion(questionID, _currentUser.id);
        }

	    public void rateQuestion(int questionID, string rating)
	    {
	        _webService.rateQuestion(_currentUser.id, questionID, rating);
	    }
	}
}

