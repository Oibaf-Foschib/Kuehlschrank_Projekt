using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fabio_Leo_Kühlschrankplaner
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

        public RefrigeratorItem(string name, string quantity, DateTime expirationDate)
        {
            Name = name;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }
    }
}


