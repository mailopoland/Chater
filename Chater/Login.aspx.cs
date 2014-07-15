using System;
using Chater.Database.Repo;
using System.Web;
using Chater.Code.ManageUsers;
using Chater.Code.ManageUsers.ManageDecorator;
using Chater.Code.ManageUsers.RememberUser;
using Chater.Code.MapSite;

namespace Chater
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RememberUser.login != null)
                Response.Redirect(MapSite.MainChat);
            if (Page.IsPostBack)
            {
                string login = GetLogin.Text;
                try
                {
                    using (ManageUsers managerSvr = new ManageUsers())
                    {
                        if (!managerSvr.IsExsistUser(login))
                        {
                            RememberUser.login = login;
                            RememberUser.hash = RememberUser.CoutHash(login);
                            Response.Redirect(MapSite.MainChat);
                        }
                    }

                }
                catch (Exception)
                {
                    Communicate.Text = "Sorry, we have problem with our application. Please try again after a moment again.";
                }

                Communicate.Text = "Login is already used by other user. Please choose other one.";
            }
        }
    }
}