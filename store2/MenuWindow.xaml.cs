using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace store2
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        Data vm;
        public MenuWindow(Data _vm)
        {
            InitializeComponent();
            vm = _vm;
            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow newWindow = new ProductsWindow();
            newWindow.Show();
        }

        private void Purchase_btn_Click(object sender, RoutedEventArgs e)
        {
            PurchaseWindow newWindow = new PurchaseWindow(vm);
            newWindow.Show();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            vm.exit();
            this.Close();
        }

        private void History_btn_Click(object sender, RoutedEventArgs e)
        {
            pastPurchasesWindow newWindow = new pastPurchasesWindow(vm);
            newWindow.Show();
        }

        private void Balance_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
