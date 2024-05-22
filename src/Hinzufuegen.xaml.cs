using System;
using System.Windows;

namespace Fabio_Leo_Kuehlschrankplaner
{
    public partial class WindowHinzufuegen : Window
    {
        private RefrigeratorManager refrigeratorManager;
        private MainWindow mainWindow; 

        
        public WindowHinzufuegen(RefrigeratorManager manager, MainWindow main)
        {
            InitializeComponent();
            refrigeratorManager = manager;
            mainWindow = main;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = txtboxName.Text;
            string quantity = txtboxMenge.Text;
            DateTime mhd = DateTime.Parse(txtboxMHD.Text);

            refrigeratorManager.AddItem(name, quantity, mhd);

            
            string item = $"{name} - {quantity} - {mhd.ToShortDateString()}";
            mainWindow.AddItemToListBox(item);

            this.Close();
        }
    }
}

