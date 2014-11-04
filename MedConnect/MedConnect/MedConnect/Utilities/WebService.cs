﻿using System;
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

		HttpClient _temp = new HttpClient ();
			
		public WebService ()
		{
			_temp.BaseAddress = new Uri("http://cancerquest.azurewebsites.net");

		}

		public async Task<ObservableCollection<Question>> testRest()
		{
			var questions = await _temp.GetStringAsync (_temp.BaseAddress + "/questions/");
            System.Diagnostics.Debug.WriteLine("i got the questions!!");
			var po =  JsonConvert.DeserializeObject<ObservableCollection<Question>>(questions);
			return po;
		}
		public async Task<User> testLogin(string username, string password) 
		{
			//using portable rest 
			System.Diagnostics.Debug.WriteLine("im here");
			RestClient rc = new RestClient { BaseUrl = "http://cancerquest.azurewebsites.net" };
			var request = new RestRequest ("/users/login/", HttpMethod.Post);
			request.AddQueryString("username", username);
			request.AddQueryString("password", password);

			System.Diagnostics.Debug.WriteLine(request);

			var response =  await rc.SendAsync<User> (request);


			System.Diagnostics.Debug.WriteLine(response.Content.username);

			//ensure success status code before trying to create 

			return response.Content;

		}
        public async Task<Question> postQuestion(string question)
        {
            RestClient rc = new RestClient { BaseUrl = "http://cancerquest.azurewebsites.net" };
            var request = new RestRequest("/questions/", HttpMethod.Post);            
			request.AddQueryString("text", question);


            var response = await rc.SendAsync<Question>(request);

			System.Diagnostics.Debug.WriteLine(response.Content.Text);
			return response.Content;
        }
        //this will be async later, where the api call is made
        public Boolean authenticate(string username, string password)
        {

            if (username.Equals(Constants.USERNAME) && password.Equals(Constants.PASSWORD))
                return true;
            return false;
        }

        public ObservableCollection<Question> getData()
        {
			ObservableCollection<Question> yolo = new ObservableCollection<Question>();

            return yolo;
        }
	}
}

