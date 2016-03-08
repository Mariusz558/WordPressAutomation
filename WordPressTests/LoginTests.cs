using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo(); //idz do strony logowania
            //LoginPage.LoginAs("admin", "password"); zaloguj sie; jedna z metod logowania
            LoginPage.LoginAs("admin").WithPassword("password").Login();//druga metoda logowania: "fluent style"

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");//sprawdza czy po zalogowaiu jestesmy na prawidlowej stronie plus komunikat bledu

            
        }
    }
}
