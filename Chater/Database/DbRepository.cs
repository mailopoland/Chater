using System;
using System.Linq;
using Chater.Database;
using System.Data.Entity;

namespace Chater.Database.Repo
{
    public class DbRepository : IDbRepository
    {
        private ChaterDbEntities db = new ChaterDbEntities();
        public DbSet<User> GetAllUsers()
        {
            return db.Users;
        }
        public bool IsExsistUser(string login){
            if ((db.Users.Where(row => row.Login == login).Count() > 0))
                return true;
            else 
                return false;
        }
        public bool IsExsistUser(string login, int hash)
        {
            if ((db.Users.Where(row => row.Login == login && row.HashSession == hash).Count() > 0))
                return true;
            else
                return false;
        }
        public void LogIn(string login, int hash)
        {
            User NewUser = new User();
            NewUser.Login = login;
            NewUser.HashSession = hash;
            db.Users.Add(NewUser);
            db.SaveChanges();
        }
        public void LogOut(string login)
        {
            db.Users.Remove(db.Users.Where(r => r.Login == login).Single());
            db.SaveChanges();
        }
        public int OpenWindow(string login)
        {
            int result = ++(db.Users.Where(row => row.Login == login).Single().NrClients);
            db.SaveChanges();
            return result;
        }
        public int CloseWindow(string login)
        {
            int result = --(db.Users.Where(row => row.Login == login).Single().NrClients);
            db.SaveChanges();
            return result;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}