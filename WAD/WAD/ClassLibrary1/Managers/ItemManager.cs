using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using DAL.DAL;

namespace ClassLibrary1.Managers
{
   public class ItemManager 
    {
        private readonly IItemDAL src;

        public ItemManager()
        {
            this.src = new ItemDAL();
        }

        public ItemManager(IItemDAL src)
        {
            this.src = src;
        }

        public List<LibraryItem> GetItems()
        {
            return src.GetItems();
        }

        public bool DeleteItem(int id)
        {
            return src.DeleteItem(id);
        }

        public void AddItem(LibraryItem item)
        {
            src.AddItem(item);
        }
    }
}
