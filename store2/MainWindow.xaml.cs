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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace store2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new Data();
            this.DataContext = vm;
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            String password = password_txt.Text.ToString();
            String username = username_txt.Text.ToString();
           if( vm.login(username, password))
            {
                MenuWindow window = new MenuWindow(vm);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }
    }
}
