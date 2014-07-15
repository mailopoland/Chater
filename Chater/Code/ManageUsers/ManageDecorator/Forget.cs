using Chater.Code.ManageUsers.RememberUser;

namespace Chater.Code.ManageUsers.ManageDecorator
{
    public class Forget : ManageDecorator
    {
        public Forget(ManageComponent component) : base(component) { }
        public override void LogOut(string loginName)
        {
            base.LogOut(loginName);
            RememberUser.RememberUser.Erease();
        }
    }
}