using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.View.Menu;
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
        public Command RedirectCommand { get; set; }
        public INavigation navigation = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public ListCategoriesVM()
        {
            RedirectCommand = new Command<string>(doRedirect);
            ListCategoryModel listCategoryModel = new ListCategoryModel();
            listCategory = listCategoryModel.GetCategories();
            ItemTappedCommand = new Command(async () => await NavigateToEditCategory());
        }

        public async Task NavigateToEditCategory()
        {
            await navigation.PushAsync(new MainPage());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void doRedirect(string opcion)
        {
            switch (opcion.ToString())
            {
                case "AddCat":
                   // navigation.PushModalAsync(new NewCategory(), true);
                    break;
            }
        }
    }
}
