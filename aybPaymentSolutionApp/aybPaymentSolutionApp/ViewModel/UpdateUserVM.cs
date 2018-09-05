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
    public class UpdateUserVM : INotifyPropertyChanged

    {

        public UserData userData { get; set; }
        public Command SaveUserCommand { get; set; }

        List<string> listStatus = new List<string>
        {
            "Active",
            "Inactive"
        };

        List<string> listSalary = new List<string>
        {
            "Hourly",
            "Salaried"
        };

        List<string> listPermission = new List<string>
        {
            "Manager",
            "Cashier",
            "Custom"
        };

        public List<string> status => listStatus;
        public List<string> salary => listSalary;
        public List<Profile> permissions { get; set; }
        Page pageView;


        public UpdateUserVM(int idUser, Page page)
        {
            this.pageView = page;
            UpdateUserModel updateUserModel = new UpdateUserModel();
            userData = updateUserModel.getUserData(idUser);
            setSelectedStatus();

            permissions = updateUserModel.getPermissions();

            SaveUserCommand = new Command(async () => await SaveUser());

        }

        public async Task SaveUser()
        {

            UserInfoResponse userInfo = new UserInfoResponse();
            userInfo.ResponseCode = "000";
            userInfo.ResponseMessage = "Save User";

            if (userData.PersonalInfo.Status == "Active")
            {
                userData.PersonalInfo.Status = "1";
            } else
            {
                userData.PersonalInfo.Status = "0";
            }

            userInfo.UserData = userData;
            UpdateUserModel updateUserModel = new UpdateUserModel();
            UserActionResponse taskSave = await updateUserModel.saveUser(userInfo);

            if (taskSave.ResponseCode == "000")
            {

                await ShowMessage("Info", "User saved!", "Ok", async () =>
                {
                    await pageView.Navigation.PushAsync(new ListUsers());
                });

            } else
            {
                await pageView.DisplayAlert("Info", "An error been ocurred, please contact Technical support", "OK");
            }
            
        }

        public void setSelectedStatus()
        {
            if (userData.PersonalInfo.Status == "False")
            {
                userData.PersonalInfo.Status = "Inactive";
            } else
            {
                userData.PersonalInfo.Status = "Active";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task ShowMessage(string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            await pageView.DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }

    }
}
