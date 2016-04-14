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
           PostCreator.Initialize();//inicjalizuje kreatora postow

           LoginPage.GoTo();// otwiera strone logowania
           LoginPage.LoginAs("mariusz").WithPassword("dkz10L02VhgmklfRE@").Login();//loguje
       }

       [TestCleanup]
       public void CloseTheBrowser()//zamyka przegladarke po zakonczonym tescie
       {
           PostCreator.CleanUp();//kreator postow sprzata testowe posty
           Driver.Close();
       }
    }
}
