using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests
{
   public class WordpressTests
    {
       [TestInitialize]//metoda wywolywana przed testami
       public void Init()
       {
           Driver.Initialize();//uruchamia przegladarke
           LoginPage.GoTo();// otwiera strone logowania
           LoginPage.LoginAs("mariusz").WithPassword("dkz10L02VhgmklfRE@").Login();//loguje
       }

       [TestCleanup]
       public void CloseTheBrowser()//zamyka przegladarke po zakonczonym tescie
       {
           Driver.Close();
       }
    }
}
