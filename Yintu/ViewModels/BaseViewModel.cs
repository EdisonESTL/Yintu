using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Yintu.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /*
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }*/

        private bool _isRegister;
        public bool IsRegister
        {
            get { return _isRegister; }
            set { _isRegister = value;
                OnPropertyChanged();
            }
        }
        private string _ciUser;
        public string CiUser
        {
            get { return _ciUser; }
            set
            {
                _ciUser = value;
                OnPropertyChanged();
            }
        }

        private string _passwordUser;
        public string PasswordUser
        {
            get
            {
                return _passwordUser;
            }
            set
            {
                _passwordUser = value;
                OnPropertyChanged();
            }
        }
    }
}
