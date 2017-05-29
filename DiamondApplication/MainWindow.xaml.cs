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

namespace DiamondApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 

    public partial class MainWindow : Window { 
    
        List<Diamond> diam;
        int j=1;
        public MainWindow(){
            InitializeComponent();
            diam = new List<Diamond>();
            diamTable.ItemsSource = diam;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e){
            if (txtID.Text != null && txtName.Text != null) {
             diam.Add(new Diamond(txtID.Text, txtName.Text, txtRatio.Text, txttypeDoping.Text, txtpercentDoping.Text));
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e){
            diam.Remove(diam[diamTable.SelectedIndex]);
            diamTable.SelectedItem = null;
        }
    }
}