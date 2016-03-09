using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace WordPressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:15662/wp-login.php");         
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }

        public class LoginCommand
        {
            private readonly string userName;
            private readonly string password;
            public LoginCommand(string userName)
            {
                this.userName = userName;
            }

            public LoginCommand WithPassword(string password)
            {
                this.password = password;
                return this;
            }

            public LoginCommand Login()
            {
                throw new NotImplementedException();
            }
        }
    }
}
