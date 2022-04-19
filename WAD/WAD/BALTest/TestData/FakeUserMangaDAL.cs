using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;
using System.Data;

namespace BALTest.TestData
{
    public class FakeUserMangaDAL : IMangaUserDAL
    {
        //simulates many-to-many relationship of a mysql table
        private readonly User[] users;
        private readonly List<KeyValuePair<int, int>> relationship;
        private readonly Manga[] manga;

        public FakeUserMangaDAL()
        {
            this.relationship = new List<KeyValuePair<int, int>>();
            this.users = new User[]
            {
                 new User(0, "user1", "user1@gmail.com", "827ccb0eea8a706c4c34a16891f84e7b", Role.USER),
                 new User(1, "user2", "user2@gmail.com", "JdVa0oOqQAr0ZMdtcTwHrQ==", Role.USER),
                 new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN)
            };
            this.manga = new Manga[]
            {
                new Manga(0, "manga1", DateTime.Now, "auth1"),
                new Manga(1, "manga2", DateTime.Now, "auth2"),
                new Manga(2, "manga3", DateTime.Now, "auth3"),
                new Manga(3, "manga4", DateTime.Now, "auth4"),
                new Manga(4, "manga5", DateTime.Now, "auth5"),
                new Manga(5, "manga6", DateTime.Now, "auth6")
            };
        }

        public Manga[] GetMangas() =>      
             this.manga;
        public User[] GetUsers() =>
            this.users;
        public List<KeyValuePair<int, int>> GetRelationship()
        {
            return this.relationship;
        }

        public void AddMangaToProfile(int uid, int mid)
        {
            var pair = new KeyValuePair<int, int>(uid, mid);
            relationship.Add(pair);
        }

        public List<Manga> GetOwnedManga(int uid)
        {
            return null;
        }

        public bool UserOwnsManga(int uid, int mid)
        {
            foreach(var pair in this.relationship)
            {
                if (uid == pair.Key && mid == pair.Value) return true;
            }
            return false;
        }

        public void RemoveOwnedManga(int uid, int mid)
        {
            var pair = new KeyValuePair<int, int>(uid, mid);
            relationship.Remove(pair);
        }
    }
}
