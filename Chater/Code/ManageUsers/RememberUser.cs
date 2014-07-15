using System;
using System.Web;

namespace Chater.Code.ManageUsers.RememberUser
{
    public static class RememberUser
    {
        public static HttpCookie curCookie
        {
            get
            {
                return HttpContext.Current.Request.Cookies[cookieName];
            }
        }
        
        public static string login
        {
            get
            {
                if (curCookie == null)
                    return null;
                return curCookie[loginCookie];
            }
            set
            {
                CreateCookieIfNotEx();
                curCookie.Values[loginCookie] = value;
                HttpContext.Current.Response.AppendCookie(curCookie);
            }
        }
        public static int hash
        {
            get
            {
                if (curCookie == null)
                    return 0;
                return Int32.Parse( curCookie[hashCookie] );
            }
            set
            {
                CreateCookieIfNotEx(); 
                curCookie.Values[hashCookie] = value.ToString();
                HttpContext.Current.Response.AppendCookie(curCookie);
            }
        }

        private static void CreateCookieIfNotEx()
        {
            if (curCookie == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Values.Add(loginCookie, null);
                cookie.Values.Add(hashCookie, (0).ToString());
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }
        public static void Erease()
        {
            if (curCookie != null)
            {
                //remove from user browerser (in next request)
                curCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.AppendCookie(curCookie);
                //remove from the server
                HttpContext.Current.Request.Cookies.Remove(cookieName);
            }
        }
        public static int CoutHash(string loginName)
        {
            return (loginName + DateTime.Now.ToString()).GetHashCode();
        }

        private const string cookieName = "_USER_";
        private const string loginCookie = "_LOGIN_";
        private const string hashCookie = "_HASH_";
        private const string nrOpenChaterCookie = "_NROPEN_";

    }
}