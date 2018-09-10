using aybPaymentSolutionApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
    class ListCategoriesVM : INotifyPropertyChanged
    {
        public List<InfoCategory> listCategory { get; set; }
        public Command ItemTappedCommand { get; set; }
        private INavigation Navigation = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public ListCategoriesVM()
        {
            ListCategoryModel listCategoryModel = new ListCategoryModel();
            listCategory = listCategoryModel.GetCategories();
            ItemTappedCommand = new Command(async () => await NavigateToEditCategory());
        }

        public async Task NavigateToEditCategory()
        {
            await Navigation.PushAsync(new MainPage());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
