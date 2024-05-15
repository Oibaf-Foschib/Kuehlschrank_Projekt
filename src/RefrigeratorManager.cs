using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
