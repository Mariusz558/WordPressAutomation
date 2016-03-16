using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace WordPressAutomation
{
    public class NewPostPage
    {

        public static void GoTo()//przechodzimy do strony dodawania nowego postu
        {
            var menuPosts = Driver.Instance.FindElement(By.Id("menu-posts"));//1 krok: klikamy element menu "Posts"
            menuPosts.Click();//klikamy w niego

            var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));//2. krok: odnajdujemy add new post
            addNew.Click();//klikamy, aby dodac nowy post
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            throw new NotImplementedException();
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand (string title)//konstruktor
        {
            this.title = title;            
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Thread.Sleep(1000);

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}
