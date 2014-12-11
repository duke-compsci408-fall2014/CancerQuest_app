using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedConnect.Models;
using Microsoft;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using PortableRest;

namespace MedConnect.Utilies
{
	public class WebService
	{

        private RestClient _rc = new RestClient { BaseUrl = "http://duke-myq.azurewebsites.net/api" };
		private string _curSesh;
        //
		public WebService ()
		{		

		}
		public void setSession(string curSesh)
		{
			_curSesh = curSesh;
		}
		private void addHeader(RestRequest request)
		{
			request.AddHeader ("X-Auth-Session", _curSesh); 
		}
		public async Task<ObservableCollection<Question>> getRecQuestions()
		{   
            var request = new RestRequest("/questions", HttpMethod.Get);
			addHeader (request);

            var response = await _rc.SendAsync<ObservableCollection<Question>>(request);

            return response.Content;
		}
		public async Task<ObservableCollection<Question>> getSortedQuestions(string type)
		{   
			var request = new RestRequest("/questions/?sort=" + type + "&order=desc", HttpMethod.Get);
			addHeader (request);

			var response = await _rc.SendAsync<ObservableCollection<Question>>(request);

			return response.Content;
		}

		public async Task<User> login(string username, string password) 
		{
			var request = new RestRequest ("/users/login/", HttpMethod.Post);
			
			request.AddQueryString("username", username);
			request.AddQueryString("password", password);
			var response =  await _rc.SendAsync<User> (request);

			//System.Diagnostics.Debug.WriteLine(response.Content.username);

			return response.Content;

		}
		public async Task<User> createUser(string username, string password, string email)
		{
			var request = new RestRequest ("/users/", HttpMethod.Post);
			request.AddQueryString("username", username);
			request.AddQueryString("password", password);
			request.AddQueryString("email", email);
			var response =  await _rc.SendAsync<User> (request);

			System.Diagnostics.Debug.WriteLine(response.Content.username);

			return response.Content;
		}
		//this posts to create a question

        public async Task<Question> postQuestion(string question)
        {
            var request = new RestRequest("/questions/", HttpMethod.Post);
			addHeader (request);
			request.AddQueryString("text", question);

            var response = await _rc.SendAsync<Question>(request);

			System.Diagnostics.Debug.WriteLine(response.Content.Text);
			return response.Content;
        }
		//this posts to user library
		public async Task<Question> postLibrary(int questionID, int userID)
		{
			string addr = "/users/" + userID + "/questions/";
			var request = new RestRequest(addr, HttpMethod.Post);
			addHeader (request);
			request.AddQueryString("id", questionID);

			var response = await _rc.SendAsync<Question>(request);

			System.Diagnostics.Debug.WriteLine("Added Question: " + response.Content.Text);
			return response.Content;
		}
		public async Task<ObservableCollection<Question>> getLibraryQuestions(int userID)
		{
            string addr = "/users/" + userID + "/questions/";

            var request = new RestRequest(addr, HttpMethod.Get);
			addHeader (request);

            var response = await _rc.SendAsync<ObservableCollection<Question>>(request);
            
            return response.Content;
		}
		public async Task<ObservableCollection<Visit>> getVisits(int userID)
		{
			string addr = "/users/" + userID + "/appointments";
			var request = new RestRequest(addr, HttpMethod.Get); 
			addHeader (request);
			var response = await _rc.SendAsync<ObservableCollection<Visit>>(request);

			return response.Content;
		}

		public async Task<Visit> getVisitQuestions(int userID, int visitID)
		{
            string addr = "/users/" + userID + "/appointments/" + visitID;

			var request = new RestRequest(addr, HttpMethod.Get); 
			addHeader (request);
			var response = await _rc.SendAsync<Visit>(request);

			return response.Content;
		}

		public async Task<Visit> createVisit(int userID)
		{
			string addr = "/users/" + userID + "/appointments";
			var request = new RestRequest(addr, HttpMethod.Post);
			addHeader (request);
            request.AddQueryString("name", "Test Appointment");


			var response = await _rc.SendAsync<Visit>(request);

			return response.Content;
		}
		public async void deleteVisit(int userID, int visitID)
		{
			string addr = "/users/" + userID + "/appointments/" + visitID;
			var request = new RestRequest(addr, HttpMethod.Delete);
			addHeader (request);
			var response = await _rc.SendAsync<Visit> (request);

            System.Diagnostics.Debug.WriteLine("yoloswag");
		}
		public async Task<Question> addQuestionVisit(int userID, int questionID, int visitID)
		{
			string addr = "/users/" + userID + "/appointments/" + visitID + "/question";

			var request = new RestRequest(addr, HttpMethod.Post);
			addHeader (request);
			request.AddQueryString("qid", questionID);
			var response = await _rc.SendAsync<Question> (request);

			return response.Content;
		}

		public async void deleteQuestionVisit(int userID, int questionID, int visitID)
		{
            string addr = "/users/" + userID + "/appointments/" + visitID + "/question";

			var request = new RestRequest(addr, HttpMethod.Delete);
			addHeader (request);
			request.AddQueryString("qid", questionID);
            
			var response = await _rc.SendAsync<Question> (request);
			System.Diagnostics.Debug.WriteLine ("yoloswag");
		}

        public async void removeLibraryQuestion(int questionID, int userID)
        {
            string addr = "/users/" + userID + "/questions/";

            var request = new RestRequest(addr, HttpMethod.Delete);
			addHeader (request);
            request.AddQueryString("id", questionID);
            await _rc.SendAsync<String>(request);
        }
        public async Task<ObservableCollection<Question>> getSearchResults(string query)
        {
            var request = new RestRequest("/questions/search?q=" + query, HttpMethod.Get);
			addHeader (request);
            var response = await _rc.SendAsync<ObservableCollection<Question>>(request);

            return response.Content;
        }	



        //tags yo:

        public async Task<ObservableCollection<Category>> getTags()
        {
            var request = new RestRequest("/tags", HttpMethod.Get);
			addHeader (request);
            var response = await _rc.SendAsync<ObservableCollection<Category>>(request);
            System.Diagnostics.Debug.WriteLine("yoloswag");

            return response.Content;
        }

		//ratings yo:

	    public async Task<Rating> getRating(int questionID)
	    {
            string addr = "/questions/" + questionID + "/rating";

            var request = new RestRequest(addr, HttpMethod.Get);
			addHeader (request);
	        var response = await _rc.SendAsync<Rating>(request);

	        return response.Content;
	    }

	    public async void rateQuestion(int userID, int questionID, string rating)
	    {
            string addr = "/questions/" + questionID + "/rating";
	        var request = new RestRequest(addr, HttpMethod.Post);
			addHeader (request);
            request.AddQueryString("user", userID);
            request.AddQueryString("vote", rating);

	        await _rc.SendAsync<Rating>(request);

	    }

		public async void addQuestionInfo(ObservableCollection<Question> questions)
		{
			foreach (Question q in questions) {
				string temp = "";

				foreach (Tag t in q.Tags) {
					temp = temp + " " + t.Text;
				}
				q.TagInfo = temp;
			}
			foreach (Question q in questions)
			{
				var rate = await getRating(q.ID);
				q.HelpfulVotes = rate.helpful;
				q.NotHelpfulVotes = rate.total - rate.helpful;
			}
		}

	}
}

