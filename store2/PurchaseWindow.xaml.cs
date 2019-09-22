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
    /// Interaction logic for PurchaseWindow.xaml
    /// </summary>
    public partial class PurchaseWindow : Window
    {
        public Data vm;
        Product p;
        //double price;
        int qty;

        public PurchaseWindow(Data _vm)
        {
            InitializeComponent();
            //vm = new Data();
            this.DataContext = _vm;
            vm = _vm;
            _vm.viewProducts();

            //products_cmb.DataContext = vm.productList;
            //products_cmb.

           
        }
        private double tots;

        private void Buy_btn_Click(object sender, RoutedEventArgs e)
            {
            if(vm.makePurchase(p, qty, tots))
            {
            MessageBox.Show("Purchase made.  Your account has been charged " + tots +".");
            this.Close();
            }
            else
            {
                MessageBox.Show("Purchase was unable to be completed.  Your account balance is below the permitted limit\n" +
                    "Please make a payment and try again");
            }
                }

        private void Products_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               p = (Product)products_cmb.SelectedItem;
                //double price = p.price;
                //int qty = int.Parse(qty_txt.Text);
                tots = p.price * qty;//((Product)(products_cmb.SelectedValue) * int.Parse(qty_txt.Text);
                total.Text = tots.ToString();
            }
            catch (Exception ex) { total.Text = "0.0"; }
        }



        private void Qty_txt_TextChanged_1(object sender, TextChangedEventArgs e)
        { try
            {
                //Product p = (Product)products_cmb.SelectedItem;
                //double price = p.price;
                qty = int.Parse(qty_txt.Text);
                tots = p.price * qty;//((Product)(products_cmb.SelectedValue) * int.Parse(qty_txt.Text);
                total.Text = tots.ToString();
            }
            catch (Exception ex) { } //total.Text = "0";

        }

        
    }


    }

