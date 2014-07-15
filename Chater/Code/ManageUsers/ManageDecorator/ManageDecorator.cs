namespace Chater.Code.ManageUsers.ManageDecorator
{
    //No sense for now :/
    public interface ManageComponent
    {
        //Decorator pattern, please add here function with you want to decorate
        void LogIn(string loginName, int hashSession);
        void LogOut(string loginName);
    }

    public class ManageDecorator : ManageComponent
    {
        private ManageComponent _component = null;
        public ManageDecorator(ManageComponent component)
        {
            _component = component;
        }
        //Decorator pattern, please add here function with you want to decorate
        public virtual void LogIn(string loginName, int hashSession)
        {
            if (_component != null)
            {
                _component.LogIn(loginName , hashSession);
            }
        }
        public virtual void LogOut(string loginName)
        {
            if (_component != null)
            {
                _component.LogOut(loginName);
            }
        }
    }
}