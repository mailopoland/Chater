using System;
using System.Web;
using System.Collections.Generic;
using Chater.Code.ManageUsers;
using Chater.Code.ManageUsers.RememberUser;
using Chater.Code.ManageUsers.ManageDecorator;
using Chater.Database;
using Chater.Code.MapSite;

namespace Chater
{
    public partial class MainChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RememberUser.login == null)
                Response.Redirect(MapSite.Login);
            Login.Text = "Logged as <b>" + RememberUser.login + "</b>";
        }
    }
}