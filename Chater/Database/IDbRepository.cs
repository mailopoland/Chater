using System;
using System.Data.Entity;

namespace Chater.Database.Repo
{
    public interface IDbRepository : IDisposable
    {
        DbSet<User> GetAllUsers();
        bool IsExsistUser(string login);
        bool IsExsistUser(string login, int hash);
        void LogIn(string login, int hash);
        void LogOut(string login);
        int OpenWindow(string login);
        int CloseWindow(string login);
    }
}
