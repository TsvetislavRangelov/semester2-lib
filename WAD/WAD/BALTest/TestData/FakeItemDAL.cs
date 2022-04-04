using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;

namespace JointInterfaces.Interfaces
{
    //public class FakeItemDAL : IItemDAL
    //{
    //    private readonly List<LibraryItem> items;

    //    public FakeItemDAL()
    //    {
    //        this.items = new List<LibraryItem>
    //        {
    //            new LibraryItem(1, "example1", GetRandomDay(), "author1", Genre.CRIME),
    //            new LibraryItem(2, "example2", GetRandomDay(), "author2", Genre.FANTASY),
    //            new LibraryItem(3, "example3", GetRandomDay(), "author3", Genre.LITERATURE)
    //        };
    //    }


    //    public List<LibraryItem> GetItems()
    //    {
    //        return this.items;
    //    }

    //    public bool DeleteItem(int id)
    //    {
    //        foreach(LibraryItem l in this.items)
    //        {
    //            if(l.Id == id)
    //            {
    //                items.Remove(l);
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void AddItem(LibraryItem item)
    //    {
    //        this.items.Add(item);
    //    }

    //    private DateTime GetRandomDay()
    //    {
    //        Random rand = new Random();
    //        DateTime initial = new DateTime(1970, 1, 1);
    //        int range = (DateTime.Today - initial).Days;
    //        return initial.AddDays(rand.Next(range));
    //    }

    //}
}
