using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Fabio_Leo_Kuehlschrankplaner
{
    public partial class MainWindow : Window
    {
        private RefrigeratorManager refrigeratorManager = new RefrigeratorManager();
        private const string FilePath = "refrigeratorItems.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadItems();

            // Überwache fixierte Artikel in regelmäßigen Abständen
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30); // Alle 30 Sekunden prüfen
            timer.Tick += (s, e) => refrigeratorManager.CheckFixedItems();
            timer.Start();
        }

        public void AddItemToListBox(string item)
        {
            lbKuehlschrank.Items.Add(item);
        }

        private void btnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            WindowHinzufuegen addItemWindow = new WindowHinzufuegen(refrigeratorManager, this);
            addItemWindow.ShowDialog();
        }

        private void btnEntfernen_Click(object sender, RoutedEventArgs e)
        {
            if (lbKuehlschrank.SelectedItem != null)
            {
                int index = lbKuehlschrank.SelectedIndex;
                refrigeratorManager.RemoveItem(refrigeratorManager.GetItems()[index]);
                lbKuehlschrank.Items.RemoveAt(index);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            refrigeratorManager.SaveToFile(FilePath);
            MessageBox.Show("Dein Kühlschrank wurde gespeichert.");
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            refrigeratorManager.LoadFromFile(FilePath);
            lbKuehlschrank.Items.Clear();
            foreach (var item in refrigeratorManager.GetItems())
            {
                lbKuehlschrank.Items.Add($"{item.Name} - {item.Quantity} - {item.ExpirationDate.ToShortDateString()}");
            }
        }

        private void btnFixieren_Click(object sender, RoutedEventArgs e)
        {
            if (lbKuehlschrank.SelectedItem != null)
            {
                int index = lbKuehlschrank.SelectedIndex;
                refrigeratorManager.FixItem(refrigeratorManager.GetItems()[index]);
                MessageBox.Show($"{refrigeratorManager.GetItems()[index].Name} wurde fixiert.", "Fixieren", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRezepte_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}



