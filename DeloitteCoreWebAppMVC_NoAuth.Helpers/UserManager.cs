using System;

namespace DeloitteCoreWebAppMVC_NoAuth.Helpers
{
    public class UserManager
    {
        public static Tuple<string, string> UserTest = new Tuple<string, string>("test", "pwd123");
        public static int UserTestId = 45;

        public static bool Login(string username, string password)
        {
            return username == UserManager.UserTest.Item1 && password == UserManager.UserTest.Item2;
        }
    }
}