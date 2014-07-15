using Chater.Code.ManageUsers.RememberUser;

namespace Chater.Code.ManageUsers.ManageDecorator
{
    public class Remember : ManageDecorator
    {
        public Remember(ManageComponent component) : base(component) { }
        public override void LogIn(string loginName, int hashSession)
        {
            base.LogIn(loginName, hashSession);
            RememberUser.RememberUser.login = loginName;
            RememberUser.RememberUser.hash = hashSession;
        }
    }
}