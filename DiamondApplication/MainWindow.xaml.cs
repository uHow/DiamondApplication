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
        Connector conn = new Connector();
        List<String> names;
        int j = 1;
        public MainWindow(){
            InitializeComponent();
            diam = new List<Diamond>();
            names = new List<String>();
            diamTable.ItemsSource = diam;
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
        }
        private void AddButton_Click(object sender, RoutedEventArgs e){
            if (txtID.Text != null && txtName.Text != null){
                conn.Insert(int.Parse(txtID.Text), txtName.Text, double.Parse(txtRatio.Text), txttypeDoping.Text, double.Parse(txtpercentDoping.Text));
                diam = conn.returnList();
                //diam.Add(new Diamond(txtID.Text, txtName.Text, txtRatio.Text, txttypeDoping.Text, txtpercentDoping.Text));
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e){
            conn.Delete(diam[listRemove.SelectedIndex].Number);
            diam = conn.returnList();
            //diam.Remove(diam[diamTable.SelectedIndex]);
            //diamTable.SelectedItem = null;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            //conn.Update(diam[diamTable.SelectedIndex].Number, diam[diamTable.SelectedIndex].Name, diam[diamTable.SelectedIndex].Ratio, diam[diamTable.SelectedIndex].TypeDoping, diam[diamTable.SelectedIndex].PercentDoping);
            conn.Update(int.Parse(updtxtID.Text), updtxtName.Text, double.Parse(updtxtRatio.Text), updtxttypeDoping.Text, double.Parse(updtxtpercentDoping.Text));
            diam = conn.returnList();
            //diam.Remove(diam[diamTable.SelectedIndex]);
            //diamTable.SelectedItem = null;
        }
        public void getSamples(){
            List<String> Samples = new List<String>();
            int i=0;
            while(i<diam.LongCount()){
                Samples.Add(diam[i].Name);
                i++;
            }
            if(Update.IsSelected == true)
                listUpdate.ItemsSource = Samples;
            if(Remove.IsSelected == true)
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