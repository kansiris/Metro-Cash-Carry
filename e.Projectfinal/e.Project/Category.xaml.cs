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
    public sealed partial class Category : Page
    {
        wcfService.MyAppProjectClient svc = new wcfService.MyAppProjectClient();
        int id;
        public Category()
        {
            this.InitializeComponent();
            ViewAllCate();
	        }

        public async  void ViewAllCate()
        {
            lstdata.DataContext = await svc.ViewAllCatAsync();
        }


        public void Clear()
        {
            txtCategory.Text = "";
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = await svc.InsertAsync(txtCategory.Text);
                MessageDialog ob = new MessageDialog(msg);
                await ob.ShowAsync();
                Clear();
                ViewAllCate();
            }
            catch(Exception ex)
            {
                
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = await svc.UpdateAsync(id, txtCategory.Text);
                MessageDialog ob = new MessageDialog(msg);
                await ob.ShowAsync();
                Clear();
                ViewAllCate();
            }
            catch (Exception ex)
            {

            }
        }

        private void lstdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                wcfService.Category ob = (wcfService.Category)lstdata.SelectedItem;
		         id = ob.CID;
                txtCategory.Text = ob.CName;
            }
            catch(Exception ex)
            {

            }
           
        }

        private async void btndelet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = await svc.DeleteAsync(id);
                MessageDialog ob = new MessageDialog(msg);
                await ob.ShowAsync();
                Clear();
                ViewAllCate();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
