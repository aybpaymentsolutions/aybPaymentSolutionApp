using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{

    public class ListUsersVM : INotifyPropertyChanged
    {
        public List<InfoUser> listUsers { get; set; }
        public Command ItemTappedCommand { get; set; }
        private INavigation Navigation = null;
        private InfoUser _currentUser;

        public event PropertyChangedEventHandler PropertyChanged;

        public InfoUser CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public ListUsersVM()
        {
            ListUsersModel listUsersModel = new ListUsersModel();
            listUsers = listUsersModel.getUsers();
            ItemTappedCommand = new Command(async () => await NavigateToEditUser());
        }

        public async Task NavigateToEditUser()
        {
            await Navigation.PushAsync(new MainPage());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
