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
    
    public partial class MainWindow : Window{

        List<Diamond> diam;
        Connector conn;
        public MainWindow()
        {
            InitializeComponent();
            conn = new Connector();
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            diam = conn.returnList();
            conn.Disconnect();
            update();
        }
            
            
        
        private void AddButton_Click(object sender, RoutedEventArgs e){
            if (txtID.Text != null && txtName.Text != null){
                conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
                conn.Insert(int.Parse(txtID.Text), txtName.Text, double.Parse(txtRatio.Text), txttypeDoping.Text, double.Parse(txtpercentDoping.Text));
                diam = conn.returnList();
                conn.Disconnect();
                update();
            }
        }
          private void RemoveButton_Click(object sender, RoutedEventArgs e){
            if (listRemove.SelectedItem != null)
            {
                conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
                conn.Delete(diam[listRemove.SelectedIndex].Number);
                diam = conn.returnList();
                conn.Disconnect();
                update();
            }
        }
        
       
        private void update()
        {
            diamTable.ItemsSource = diam;
            listUpdate.ItemsSource = diam;
            listRemove.ItemsSource = diam;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listUpdate.SelectedItem != null)
            {
                conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
                conn.Update(int.Parse(updtxtID.Text), updtxtName.Text, double.Parse(updtxtRatio.Text), updtxttypeDoping.Text, double.Parse(updtxtpercentDoping.Text));
                diam = conn.returnList();
                conn.Disconnect();
                update();
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (listUpdate.SelectedItem != null)
            {
                updtxtID.Text = diam[listUpdate.SelectedIndex].Number.ToString();
                updtxtName.Text = diam[listUpdate.SelectedIndex].Name;
                updtxtRatio.Text = diam[listUpdate.SelectedIndex].Ratio.ToString();
                updtxtpercentDoping.Text = diam[listUpdate.SelectedIndex].PercentDoping.ToString();
                updtxttypeDoping.Text = diam[listUpdate.SelectedIndex].TypeDoping;
            }
        }
    }
}