using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZeroApp.ForecastTracker.Client.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
        
        private readonly Dictionary<string, IEnumerable> _propertyErrors = new Dictionary<string, IEnumerable>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnErrorsChanged(object sender, string propertyName)
        {
            ErrorsChanged?.Invoke(sender, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            IEnumerable propertyErrors = null;

            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrWhiteSpace(propertyName))
                return new List<object>();
            lock (_propertyErrors)
            {
                if (_propertyErrors.ContainsKey(propertyName))
                {
                    propertyErrors = _propertyErrors[propertyName];
                }
            }

            return propertyErrors ?? new List<object>();
        }

        public bool HasErrors
        {
            get
            {
                bool found;

                lock (_propertyErrors)
                {
                    found = (_propertyErrors.Count > 0);
                }

                return found;
            }
        }

        protected virtual void PropertyIsValid(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrWhiteSpace(propertyName)) return;
            lock (_propertyErrors)
            {
                if (!_propertyErrors.ContainsKey(propertyName)) return;
                _propertyErrors.Remove(propertyName);
                OnErrorsChanged(this, propertyName);
            }
        }

        protected virtual void PropertyIsInValid(string propertyName, IEnumerable errors)
        {
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrWhiteSpace(propertyName)) return;
            lock (_propertyErrors)
            {
                if (_propertyErrors.ContainsKey(propertyName))
                {
                    _propertyErrors.Remove(propertyName);
                }

                _propertyErrors.Add(propertyName, errors);
                OnErrorsChanged(this, propertyName);
            }
        }
    }
}
