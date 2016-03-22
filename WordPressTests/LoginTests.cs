using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class LoginTests : WordpressTests
    {   
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            //LoginPage.GoTo(); //idz do strony logowania (Ref)
            ////LoginPage.LoginAs("admin", "password"); zaloguj sie; jedna z metod logowania
            //LoginPage.LoginAs("mariusz").WithPassword("dkz10L02VhgmklfRE@").Login();//druga metoda logowania: "fluent style"

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");//sprawdza czy po zalogowaiu jestesmy na prawidlowej stronie plus komunikat bledu
                       
        }
        //test failujacy
        //[TestMethod]
        //public void Admin_User_Cannot_Login()
        //{
        //    LoginPage.GoTo(); //idz do strony logowania
        //    //LoginPage.LoginAs("admin", "password"); zaloguj sie; jedna z metod logowania
        //    LoginPage.LoginAs("mariusz").WithPassword("AAAdkz10L02VhgmklfRE@").Login();//druga metoda logowania: "fluent style"

        //    Assert.IsTrue(DashboardPage.IsAt, "Failed to login");//sprawdza czy po zalogowaiu jestesmy na prawidlowej stronie plus komunikat bledu

        //}
    }
}
