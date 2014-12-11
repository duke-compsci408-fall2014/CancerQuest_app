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
    public class SearchViewModel : ViewModel
    {
        private WebService _webService;

        private ObservableCollection<Question> _results;

        public ObservableCollection<Question> Results
        {
            get
            {
                return _results;
            }
            set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        public SearchViewModel(WebService webservice)
        {
            _webService = webservice;
            _results = new ObservableCollection<Question>();
        }

        public async Task<bool> getSearchResults(string query)
        {
            Results.Clear();

            var tmp = await _webService.getSearchResults(query);
            Results = tmp;
			_webService.addQuestionInfo (Results);

            return true;
        }


    }
}
