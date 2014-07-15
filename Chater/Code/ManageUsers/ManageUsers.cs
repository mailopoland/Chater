using System;
using System.Collections.Generic;
using System.Linq;
using Chater.Database;
using Chater.Database.Repo;
using Chater.Code.ManageUsers.ManageDecorator;

namespace Chater.Code.ManageUsers
{
    public class ManageUsers : ManageComponent, IDisposable
    {
        protected IDbRepository _repo = null;
 
        public ManageUsers() 
        { 
            _repo = new DbRepository();
        }
        public ManageUsers(IDbRepository repo) 
        {
            _repo = repo; 
        }

        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers().ToList();
        }
        public bool IsExsistUser(string loginName)
        {
            return _repo.IsExsistUser(loginName);
        }

        public bool IsExsistUser(string loginName, int hashSession)
        {
            return _repo.IsExsistUser(loginName, hashSession);
        }
        public int OpenWindow(string loginName)
        {
            return _repo.OpenWindow(loginName);
        }
        public int CloseWindow(string loginName)
        {
            return _repo.CloseWindow(loginName);
        }

        public void LogIn(string loginName, int hashSession)
        {
            _repo.LogIn(loginName, hashSession);
        }
        public void LogOut(string loginName)
        {
            _repo.LogOut(loginName);
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}