using System;
using System.Collections.ObjectModel;
using System.Globalization;
using MedConnect.Utilies;
using MedConnect.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedConnect
{
	public class TagTranslator
	{
		private WebService _webService;
		private Dictionary<int,ObservableCollection<Tag>> dicTags;
		private ObservableCollection<Category> allCategories;

		public TagTranslator (WebService webservice)
		{
			_webService = webservice;
			dicTags = new Dictionary<int, ObservableCollection<Tag>> ();
            allCategories = new ObservableCollection<Category>();
            getCategories();

		}

		public string getTagName(int categoryID, int tagID)
		{
			string tagName = "temp";
			ObservableCollection<Tag> cur = dicTags [categoryID];
			foreach (Tag t in cur) {
				if (t.id == tagID) {
					tagName = t.Text;
				}
			}
			System.Diagnostics.Debug.WriteLine(tagName);
			return tagName;
		}

        public async void getCategories()
        {
            var temp = await _webService.getTags();
            allCategories = temp;
			//initializeCategoryDict();
        }

        private void initializeCategoryDict()
        {
            foreach(Category q in allCategories)
            {
                dicTags.Add(q.id, q.Tag);
            }

			System.Diagnostics.Debug.WriteLine("yolo");
        }
		/*
		 * Get all tags
		 * foreach tag, create new entry in dictionary. map tag id to tag name. 
		 * each question will get tag
		 * 
		*


	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	        
	    }

	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	        
	    }
         */
	}
}

