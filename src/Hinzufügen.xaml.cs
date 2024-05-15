using System;
using System.Windows;

namespace Fabio_Leo_Kühlschrankplaner
{
    public partial class Window1 : Window
    {
        private RefrigeratorManager refrigeratorManager;
        private MainWindow mainWindow; 

        
        public Window1(RefrigeratorManager manager, MainWindow main)
        {
            InitializeComponent();
            refrigeratorManager = manager;
            mainWindow = main;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string quantity = Menge.Text;
            DateTime mhd = DateTime.Parse(MHD.Text);

            refrigeratorManager.AddItem(name, quantity, mhd);

            
            string item = $"{name} - {quantity} - {mhd.ToShortDateString()}";
            mainWindow.AddItemToListBox(item);

            this.Close();
        }
    }
}

