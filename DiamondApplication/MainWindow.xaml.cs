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

namespace DiamondApplication{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    public partial class MainWindow : Window{

        List<Diamond> diam;
        Connector conn;
        public MainWindow(){
            InitializeComponent();
            conn = new Connector();  
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            diam = conn.returnList();
            conn.Disconnect();
            diamTable.ItemsSource = diam;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e){
            if (txtID.Text != null && txtName.Text != null){
                conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
                conn.Insert(int.Parse(txtID.Text), txtName.Text, double.Parse(txtRatio.Text), txttypeDoping.Text, double.Parse(txtpercentDoping.Text));
                diam = conn.returnList();
                diamTable.ItemsSource = diam;
                conn.Disconnect();
            }
        }
        
    }
}