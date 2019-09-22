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
    /// Interaction logic for pastPurchasesWindow.xaml
    /// </summary>
    public partial class pastPurchasesWindow : Window
    {
        public Data vm;
        //public bool useDates = false;
        public pastPurchasesWindow(Data _vm)
        {
            InitializeComponent();
            vm = _vm;
            DataContext = vm;
            //purchasesInfo.ItemsSource = vm.pastPurchases;

        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            List<Func<purchase, bool>> funcs = new List<Func<purchase, bool>>();
            if ((bool)dates.IsChecked)
            {
                funcs.Add((purchase p) => p.purchase_date >= fromdt.DisplayDate && p.purchase_date <= todt.DisplayDate); 
            }
            if ((bool)Prices.IsChecked)
            {
                funcs.Add((purchase p) => p.total >= decimal.Parse(PriceFrom.Text) && p.total <= decimal.Parse(PriceTo.Text));
            }
            vm.filterHistory(funcs);
            purchasesInfo.ItemsSource = vm.pastPurchases;
        }
    }
}
