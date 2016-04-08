using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class PageTests : WordpressTests
    {
        [TestMethod]
        public void Can_Edit_A_Page()//testujemy dodawanie nowego postu
        {   //kolejne kroki: (Ref)
            //LoginPage.GoTo();// otwiera strone logowania
            //LoginPage.LoginAs("mariusz").WithPassword("dkz10L02VhgmklfRE@").Login();//logowanie; kroki 1 i 2 maja potencjal na refactoring, aby nie trzeba bylo powtarzac za kazdym razem przy nowym tescie logowania od samego poczatku.

            ListPostsPage.GoTo(PostType.Page);//dlatego, ze nie chcemy, aby osoba robiaca testy przekazywala tu wprost linki do stron musi byc tutaj klasa, ktora bedzie miala zaprogramowane strony jako obiekty i nie bedzie mozliwosci dodawania innych strony z poziomu testu
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
    }
}
