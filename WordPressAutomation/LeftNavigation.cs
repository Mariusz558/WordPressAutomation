using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace WordPressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    //kod zabrany z metody GoTo() w klasie NewPostPages
                    var menuPosts = Driver.Instance.FindElement(By.Id("menu-posts"));//1 krok: klikamy element menu "Posts"
                    menuPosts.Click();//klikamy w niego

                    var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));//2. krok: odnajdujemy add new post
                    addNew.Click();//klikamy, aby dodac nowy post
                }
            }
        }
        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    //kod zabrany z metody GoTo() w klasie ListPostPages
                    Driver.Instance.FindElement(By.Id("menu-pages")).Click();
                    Driver.Instance.FindElement(By.LinkText("All Pages")).Click();
                }
            }
        }
    }
}
