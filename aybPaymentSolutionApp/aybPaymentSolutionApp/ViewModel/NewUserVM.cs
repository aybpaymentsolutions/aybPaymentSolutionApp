using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.View;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
    public class NewUserVM : INotifyPropertyChanged
    {
        string iddevice = CrossDeviceInfo.Current.Id;

        public UserData userData {
            get => _userData;
            set {
                _userData = value;
                OnPropertyChanged();
            }
        }

        public Command SaveUserCommand { get; set; }
        public Command getOptions { get; set; }

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

        public List<string> status => listStatus;
        public List<string> salary => listSalary;
        public List<Profile> permissions { get; set; }

        Page pageView;
        private UserData _userData;

        public NewUserVM(Page page)
        {
            PersonalInfo personalObj = new PersonalInfo();
            SalaryInfo salaryObj = new SalaryInfo();
            ContactInfo contactObj = new ContactInfo();
            userData = new UserData();
            userData.ContactInfo = contactObj;
            userData.PersonalInfo = personalObj;
            userData.SalaryInfo = salaryObj;
            pageView = page;

            UpdateUserModel updateUserModel = new UpdateUserModel();
            permissions = updateUserModel.getPermissions();

            SaveUserCommand = new Command(async () => await SaveUser());
        }

        public async Task SaveUser()
        {

            UserInfoResponse userInfo = new UserInfoResponse();
            userInfo.ResponseCode = "000";
            userInfo.ResponseMessage = "Save User";

            if (userData.PersonalInfo.Status == "Activate")
            {
                userData.PersonalInfo.Status = "1";
            }
            else
            {
                userData.PersonalInfo.Status = "0";
            }

            userData.PersonalInfo.DeviceId = iddevice;

            userInfo.UserData = userData;
            UpdateUserModel updateUserModel = new UpdateUserModel();
            UserActionResponse taskSave = await updateUserModel.saveUser(userInfo);

            if (taskSave.ResponseCode == "000")
            {

                await ShowMessage("Info", "User saved!", "Ok", async () =>
                {
                    await pageView.Navigation.PushAsync(new ListUsers());
                });

            }
            else
            {
                await pageView.DisplayAlert("Info", "An error been ocurred, please contact Technical support", "OK");
            }

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




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
