﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordPressAutomation;

namespace WordPressAutomation
{
    public class NewPostPage
    {

        public static void GoTo()//przechodzimy do strony dodawania nowego postu
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)//torzenie nowego posta; przy pomocy fluent interfaces
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            //return Driver.Instance.FindElement(By.Id("edit-slug-buttons")) != null;
            return Driver.Instance.FindElement(By.XPath(".//*[@id='publish']")) != null;
        }

        public static string Title 
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
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

        public CreatePostCommand WithBody(string body)//dodawanie tresci posta; CreatePost("Post title").WithBody("this is a test body")
        {
            this.body = body;
            return this;
        }

        public void Publish()//metoda bez zmiennych; tak tez mozna pisac automaty; zaleta mniej linijek kodu (wole ze zmiennymi narazie)
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            //Thread.Sleep(5000);//czeka 5 sec. przed kliknieciem w publish (Ref)
            Driver.Wait(TimeSpan.FromSeconds(1));

            Driver.Instance.FindElement(By.Name("publish")).Click();
        }
    }
}
