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
    public sealed partial class SearchPage : Page
    {
        wcfService.MyAppProjectClient svc = new wcfService.MyAppProjectClient();
        wcfService.Product p = new wcfService.Product();
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("A");
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("B");
        }
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("C");
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("D");
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("E");
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("F");
        }
        private async void Button_Click_7(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("G");
        }
        private async void Button_Click_8(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("H");
        }
        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("I");
        }
        private async void Button_Click_10(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("J");
        }
        private async void Button_Click_11(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("K");
        }

        private async void Button_Click_12(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("L");
        }
        private async void Button_Click_13(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("M");
        }

        private async void Button_Click_14(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("N");
        }

        private async void Button_Click_15(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("O");
        }

        private async void Button_Click_16(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("P");
        }
        private async void Button_Click_17(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("Q");
        }
        private async void Button_Click_18(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("R");
        }
        private async void Button_Click_19(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("S");
        }
        private async void Button_Click_20(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("T");
        }
        private async void Button_Click_21(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("U");
        }
        private async void Button_Click_22(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("V");
        }
        private async void Button_Click_23(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("W");
        }
        private async void Button_Click_24(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("X");
        }
        private async void Button_Click_25(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("Y");
        }
        private async void Button_Click_26(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync("Z");
        }

        private async void Button_Click_27(object sender, RoutedEventArgs e)
        {
            lstdata1.DataContext = await svc.ViewAllProductSerchAsync(SerchBox.Text);
        }

       
    }
}
