using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests
{
    [TestClass]
    class CreatePostTests
    {
        [TestInitialize]//metoda wywolywana przed testami
        public void Init()
        {
            Driver.Initialize();//uruchamia przegladarke
        }

        [TestMethod]
        public void Can_Create_A_Basic_Post()//testujemy dodawanie nowego postu
        {   //kolejne kroki:
            LoginPage.GoTo();// otwiera strone logowania
            LoginPage.LoginAs("mariusz").WithPassword("dkz10L02VhgmklfRE@").Login();//logowanie; kroki 1 i 2 maja potencjal na refactoring, aby nie trzeba bylo powtarzac za kazdym razem przy nowym tescie logowania od samego poczatku.
            
            NewPostPage.GoTo();//wchodzimy na strone dodawania nowego posta
            NewPostPage.CreatePost("This is the test post title")//tworzymy nowy post; urzywamy tu podobnie jak przy logowaniu fluid interfaces
                .WithBody("Hi, this is the body")
                .Publish();
            NewPostPage.GoToNewPost();//wyswietlamy nowy post

            Assert.AreEqual(PostPage.Title, "This is the new post title", "Title did not match the new post");//sprawdzymy czy faktycznie wyswietlony zostal dodany w tescie post

        }
        [TestCleanup]
        public void CloseTheBrowser()//zamyka przegladarke po zakonczonym tescie
        {
            Driver.Close();
        }
    }
    }
}
