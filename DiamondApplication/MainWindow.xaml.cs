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
        List<String> Samples;
        Connector conn;
        public MainWindow(){
            InitializeComponent();
            conn = new Connector();  
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            diam = conn.returnList();
            conn.Disconnect();
            diamTable.ItemsSource = diam;
            getSamples();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e){
            if (txtID.Text != null && txtName.Text != null){
                conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
                conn.Insert(int.Parse(txtID.Text), txtName.Text, double.Parse(txtRatio.Text), txttypeDoping.Text, double.Parse(txtpercentDoping.Text));
                diam = conn.returnList();
                conn.Disconnect();
                diamTable.ItemsSource = diam;
                getSamples();
            }
        }
          private void RemoveButton_Click(object sender, RoutedEventArgs e){
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            conn.Delete(diam[listRemove.SelectedIndex].Number);
            diam = conn.returnList();
            conn.Disconnect();
            diamTable.ItemsSource = diam;
            getSamples();
            //diam.Remove(diam[diamTable.SelectedIndex]);
            //diamTable.SelectedItem = null;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            //conn.Update(diam[diamTable.SelectedIndex].Number, diam[diamTable.SelectedIndex].Name, diam[diamTable.SelectedIndex].Ratio, diam[diamTable.SelectedIndex].TypeDoping, diam[diamTable.SelectedIndex].PercentDoping);
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            conn.Update(int.Parse(updtxtID.Text), updtxtName.Text, double.Parse(updtxtRatio.Text), updtxttypeDoping.Text, double.Parse(updtxtpercentDoping.Text));
            diam = conn.returnList();
            conn.Disconnect();
            diamTable.ItemsSource = diam;
            getSamples();
            //diam.Remove(diam[diamTable.SelectedIndex]);
            //diamTable.SelectedItem = null;
        }
        public void getSamples(){
            Samples.Clear();
            int i=0;
            while(i<diam.LongCount()){
                Samples.Add(diam[i].Name);
                i++;
            }
            //if(Update.IsSelected == true)
                listUpdate.ItemsSource = Samples;
            //if(Remove.IsSelected == true)
                listRemove.ItemsSource = Samples;
        }

        private void listUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e){
            updtxtID.Text = diam[listUpdate.SelectedIndex].Number.ToString();
            updtxtName.Text = diam[listUpdate.SelectedIndex].Name;
            updtxtRatio.Text = diam[listUpdate.SelectedIndex].Ratio.ToString();
            updtxtpercentDoping.Text = diam[listUpdate.SelectedIndex].PercentDoping.ToString();
            updtxttypeDoping.Text = diam[listUpdate.SelectedIndex].TypeDoping;
        }
    }
}