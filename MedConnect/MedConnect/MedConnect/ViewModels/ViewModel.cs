using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace MedConnect
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var propertyName = ((MemberExpression) projection.Body).Member.Name;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
                OnPropertyChanged();
            }
        }
    }
}

