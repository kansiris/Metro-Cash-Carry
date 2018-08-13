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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace e.Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowallDat : Page
    {
        wcfService.MyAppProjectClient svc = new wcfService.MyAppProjectClient();
        public ShowallDat()
        {
            this.InitializeComponent();
            ViewAllCate();
        }
        public async void ViewAllCate()
        {
            lstdata.DataContext = await svc.ViewAllCatAsync();
            lstdata1.DataContext = await svc.ViewAllProductAsync();
            lstdata2.DataContext = await svc.ViewAllBrandAsync();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
