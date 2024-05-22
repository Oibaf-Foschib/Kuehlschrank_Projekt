using System;
using System.Windows;
using System.Windows.Controls;

namespace Fabio_Leo_Kühlschrankplaner
{
    public partial class MainWindow : Window
    {
        private RefrigeratorManager refrigeratorManager = new RefrigeratorManager();
        private const string FilePath = "refrigeratorItems.json"; // Dateipfad für die Speicherung

        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
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
            if (lbKühlschrank.SelectedItem != null)
            {
                int index = lbKühlschrank.SelectedIndex;
                refrigeratorManager.RemoveItem(refrigeratorManager.GetItems()[index]);
                lbKühlschrank.Items.RemoveAt(index);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            refrigeratorManager.SaveToFile(FilePath);
            MessageBox.Show("Daten wurden gespeichert.");
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            refrigeratorManager.LoadFromFile(FilePath);
            lbKühlschrank.Items.Clear();
            foreach (var item in refrigeratorManager.GetItems())
            {
                lbKühlschrank.Items.Add($"{item.Name} - {item.Quantity} - {item.ExpirationDate.ToShortDateString()}");
            }
        }

        private void btnFixieren_Click(object sender, RoutedEventArgs e)
        {
            // Deine Implementierung für Fixieren
        }

        private void btnRezepte_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}


