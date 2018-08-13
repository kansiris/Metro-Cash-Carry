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
    public sealed partial class Brands : Page
    {
       wcfService.MyAppProjectClient svc = new wcfService.MyAppProjectClient();
       int id;
       int cat_id;
        public Brands()
        {
            this.InitializeComponent();
            CboxData();
            viewallBrands();
        }

        public async void CboxData()
        {
            CBoxCategory.DataContext = await svc.ViewAllCatAsync();
        }

        public async  void viewallBrands()
        {
            lstdata.DataContext = await svc.ViewAllBrandAsync();
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        public void cleare()
        {
            textBrands.Text = "";
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wcfService.Category Cat = (wcfService.Category)CBoxCategory.SelectedItem;

                string msg = await svc.InsertBrandAsync(Cat.CID, txtBrand.Text);
                MessageDialog ob = new MessageDialog(msg);
                await ob.ShowAsync();
                cleare();
                viewallBrands();

            }

            catch(Exception ex)
            {
               
            }

        }

        private void lstdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                wcfService.Brands brand = (wcfService.Brands)lstdata.SelectedItem;
                //txtBrand.Text 4
                id = brand.BID;
                txtBrand.Text = brand.BName;
                

            }
            catch(Exception ex)
            {

            }
         
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wcfService.Category cat = (wcfService.Category)CBoxCategory.SelectedItem;
                
                string msg=await svc.UpdateBrandAsync(id, txtBrand.Text,cat.CID);
                MessageDialog ms = new MessageDialog(msg);
              await  ms.ShowAsync();
              viewallBrands();
                
            }
            catch(Exception ex)
            {

            }
        }

        private async void btndelet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = await svc.DeleteBrandAsync(id);
                MessageDialog ms =new MessageDialog(msg);
                 await  ms.ShowAsync();
                 viewallBrands();
            }
            catch(Exception ex)
            {

            }
        }

    }
}
