using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Fabio_Leo_Kuehlschrankplaner
{
    public class RefrigeratorManager
    {
        private List<RefrigeratorItem> items = new List<RefrigeratorItem>();

        public void AddItem(string name, string quantity, DateTime expirationDate)
        {
            items.Add(new RefrigeratorItem(name, quantity, expirationDate));
        }

        public void RemoveItem(RefrigeratorItem item)
        {
            items.Remove(item);
        }

        public List<RefrigeratorItem> GetItems()
        {
            return items;
        }

        public void FixItem(RefrigeratorItem item)
        {
            item.IsFixed = true;
        }

        public void CheckFixedItems()
        {
            foreach (var item in items)
            {
                if (item.IsFixed && int.TryParse(item.Quantity, out int quantity) && quantity <= 0)
                {
                    MessageBox.Show($"Bitte {item.Name} nachkaufen!", "Nachkaufen", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UpdateShoppingList(item);
                }
            }
        }

        private void UpdateShoppingList(RefrigeratorItem item)
        {
            string shoppingListPath = "einkaufsliste.txt";
            string entry = $"{item.Name} - {item.Quantity} - {item.ExpirationDate.ToShortDateString()}\n";
            File.AppendAllText(shoppingListPath, entry); // Datei wird erstellt, falls sie nicht existiert
        }

        public void SaveToFile(string filePath)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                items = JsonConvert.DeserializeObject<List<RefrigeratorItem>>(json);
            }
            else
            {
                items = new List<RefrigeratorItem>();
            }
        }
    }

    public class RefrigeratorItem
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsFixed { get; set; } // Neue Eigenschaft

        public RefrigeratorItem(string name, string quantity, DateTime expirationDate)
        {
            Name = name;
            Quantity = quantity;
            ExpirationDate = expirationDate;
            IsFixed = false;
        }
    }
}



