using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace aybPaymentSolutionApp.Controllers
{
    public class MainListView
    {
        private ContentListExpandable _oldProduct;
        public ObservableCollection<ContentListExpandable> Products { get; set; }



        public MainListView()
        {
            Products = new ObservableCollection<ContentListExpandable>
            {
                new ContentListExpandable
                {
                    Title = "Microsoft Surface",

                    IsVisible =false
                },
                new ContentListExpandable
                {
                    Title = "Microsoft Lumia 535",
                    IsVisible = false
                },
                new ContentListExpandable
                {
                    Title = "Microsoft 650",
                    IsVisible = false
                },
                new ContentListExpandable
                {
                    Title = "Lenovo Surface",
                    IsVisible =  false
                },
                new ContentListExpandable
                {
                    Title = "Microsoft edge",
                    IsVisible = false
                }
            };

        }
        public void ShoworHiddenProducts(ContentListExpandable product)
        {
            if (_oldProduct == product)
            {
                product.IsVisible = !product.IsVisible;
                UpDateProducts(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    _oldProduct.IsVisible = false;
                    UpDateProducts(_oldProduct);

                }
                product.IsVisible = true;
                UpDateProducts(product);
            }
            _oldProduct = product;
        }

        private void UpDateProducts(ContentListExpandable product)
        {

            var Index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(Index, product);

        }
    }
}
