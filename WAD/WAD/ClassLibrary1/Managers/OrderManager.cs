using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;

namespace ClassLibrary1.Managers
{
   public class OrderManager : IItemDAL
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
