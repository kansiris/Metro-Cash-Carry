using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace e.Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddProducts : Page
    {

        wcfService.MyAppProjectClient svc = new wcfService.MyAppProjectClient();
        int id;
        public AddProducts()
        {
            this.InitializeComponent();
            Category();
            viewData();
        }

     
        public  async void Category()
        {
            cboxCategory.DataContext = await svc.ViewAllCatAsync();
        }
        public async void viewData()
        {
            lstdata1.DataContext = await svc.ViewAllProductAsync();
        }


        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnInsert1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wcfService.Category Cat = (wcfService.Category)cboxCategory.SelectedItem;
                wcfService.Brands b = (wcfService.Brands)cBoxBrands.SelectedItem;
                string msg = await svc.InsertProductAsync(txtProduct.Text, txtPrice.Text, txtQuantity.Text, Cat.CID, b.BID);
                MessageDialog ob = new MessageDialog(msg);
                await ob.ShowAsync();
                viewData();
               
            }
            catch(Exception ex)
            {

            }

        }

        private async void cboxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                wcfService.Category ob = (wcfService.Category)cboxCategory.SelectedItem;
                cBoxBrands.DataContext = await svc.ViewAllBrandByCatAsync(ob.CID);
            }
            catch (Exception ex)
            {

            }
        }

        private async void btnUpdate1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wcfService.Category Cat = (wcfService.Category)cboxCategory.SelectedItem;
                wcfService.Brands b = (wcfService.Brands)cBoxBrands.SelectedItem;
                string msg=await svc.UpdateProductAsync(id,txtProduct.Text,txtPrice.Text,txtQuantity.Text,Cat.CID,b.BID);
                MessageDialog ms = new MessageDialog(msg);
                await ms.ShowAsync();
                viewData();
            }
            catch(Exception ex)
            {

            }
        }

        private void lstdata1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                wcfService.Product pro = (wcfService.Product)lstdata1.SelectedItem;
                txtPrice.Text = pro.Price;
                txtProduct.Text = pro.PName;
                txtQuantity.Text = pro.QUNTITY;
                id = pro.PID;

                
            }
            catch(Exception ex)
            {

            }
        }

        private async void btndelet1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = await svc.DeleteProductAsync(id);
                MessageDialog ms = new MessageDialog(msg);
               await ms.ShowAsync();
               viewData();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
