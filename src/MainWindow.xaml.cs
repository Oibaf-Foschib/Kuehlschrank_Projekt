using System;
using System.Windows;
using System.Windows.Controls;

namespace Fabio_Leo_Kühlschrankplaner
{
    public partial class MainWindow : Window
    {
        private RefrigeratorManager refrigeratorManager = new RefrigeratorManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddItemToListBox(string item)
        {
            lbKühlschrank.Items.Add(item);
        }

        private void btnHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 addItemWindow = new Window1(refrigeratorManager, this);
            addItemWindow.ShowDialog();
        }

        private void btnEntfernen_Click(object sender, RoutedEventArgs e)
        {
            lbKühlschrank.Items.Remove(lbKühlschrank.SelectedItem);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFixieren_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRezepte_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}
