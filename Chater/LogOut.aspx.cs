using System;
using Chater.Code.ManageUsers.RememberUser;

namespace Chater
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RememberUser.Erease();
            LoginAgain.NavigateUrl = "/Login";
        }
    }
}