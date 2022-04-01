using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace ClassLibrary1.Managers
{
   public class OrderManager
    {
        readonly private List<LibraryItem> orderedItems;


        public OrderManager()
        {
            this.orderedItems = new List<LibraryItem>();
        }

        public void AddToCart(LibraryItem item)
        {
            orderedItems.Add(item);
        }


    }
}
