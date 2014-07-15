using System;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Chater.Code.ManageUsers;
using Chater.Code.ManageUsers.RememberUser;
using Chater.Code.ManageUsers.ManageDecorator;
using Chater.Database;
using Chater.Code.MapSite;

namespace Chater
{
    public class JsRuner : Hub
    {
        private string loginName{
            get{
                return RememberUser.login;               
            }
        }
        private int hashSession
        {
            get
            {
                return RememberUser.hash;
            }
        }

        public void LogIn()
        {
            using (ManageUsers manager = new ManageUsers())
            {
                if (!manager.IsExsistUser(loginName))
                {
                    manager.LogIn(loginName, hashSession );
                    Clients.Others.addUser(loginName);
                }
                //if true that means that somebody new is loged on the same login like in our cookie
                else if (!manager.IsExsistUser(loginName, hashSession))
                {
                    RememberUser.Erease();
                    HttpContext.Current.Response.Redirect(MapSite.Login);
                    return;
                }
                List<User> users = manager.GetAllUsers();
                Register();
                foreach (var us in users)
                {
                    Clients.Caller.addUser(us.Login);
                }
                manager.OpenWindow(loginName);
            }
        }

        public void LogOut()
        {
            using (ManageUsers manager = new ManageUsers())
            {
                Unregister();
                //remove one open Chater
                if (manager.CloseWindow(loginName) == 0)
                {
                    manager.LogOut(loginName);
                    Clients.Others.removeUser(loginName);
                }
                    
            }
            
        }

        public void LogOutAll()
        {
            Clients.Group(loginName).logOut();
        }

        private Task Register()
        {
            return Groups.Add(Context.ConnectionId, loginName);
        }

        private Task Unregister()
        {
            return Groups.Remove(Context.ConnectionId, loginName);
        }


        public void SendMessage(string txt)
        {
            Clients.All.displayMsg(loginName, txt);
        }
    }
}