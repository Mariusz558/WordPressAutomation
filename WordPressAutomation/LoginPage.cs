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

        public static LoginCommand LoginAs(string userName)//pierwsza metoda z ciagu metod wywolywanych na klasie LoginPage w tescie; fluent interface za pomoca fabryki; http://stackoverflow.com/questions/515269/factory-pattern-in-c-how-to-ensure-an-object-instance-can-only-be-created-by-a
        {
            return new LoginCommand(userName);//tworzymy komende logowania; metoda LoginAs wywolywana na klasie LoginPage bedzie zwracac obiekt klasy LoginCommand z parametrem, ktorym jest zadany userName
        }

        public class LoginCommand//klasa komendy logowania, ktora zawiera nastepne z ciagu metod wywolywanych w tescie na klasie LoginPage
        {
            private readonly string userName;
            private readonly string password;
            public LoginCommand(string userName)//konstruktor
            {
                this.userName = userName;
            }

            public LoginCommand WithPassword(string password)
            {
                this.password = password;
                return this;
            }

            public LoginCommand Login()//tu bedzie sie odbywalo wypelnianie pol logowania i klikanie w guziki
            {
                Driver.Instance.
            }
        }
    }
}
