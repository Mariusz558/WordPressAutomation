using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace WordPressAutomation
{
    public class ListPostsPage
    {
        private static int lastCount;
        public static int PreviousPostCount 
        {
            get { return lastCount; }
        }

        public static int CurrentPostCount 
        {
            get { return GetPostCount(); }
        }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }
        
        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }



        public static bool DoesAPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)//metoda przeszukuje wszystie wiersze na stronie w poszukiwaniu wierszy z zapodanym tytulem. Jesli znajdzie wiecej niz 0 takich wierszy najezdza mysza na znaleziony wiersz, aby wyswietic opcje trash i klina w nia, aby usunac dany post. (As simple as that kurwa!)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;//???
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));//wylaczenie waita na czas wykonywania akcji

                if (links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);//using OpenQA.Selenium.Interactions
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
        }

        public static void SearchForPost(string searchString)
        {
            //refactoring GoTo() w testach
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }

            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }

        public static bool IsAt
        {
                get //sprawdza czy jestesmy na stronie
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));//aby tego dokonac (zwrocic wart. logiczna) wyszukujemy wszystkie elementy o tagu h1 na stronie
                if (h1s.Count > 0)//jesli mamy ich wiecej niz 0
                    return h1s[0].Text == "Posts";//zwroc pierwszy, ktorego text jest Dashboard
                return false;//jesli nie ma h1 zwroc falsz - nie jestesmy na stronie Dashboard
            }            
            }
    }
    public enum PostType
    {
        Page,
        Posts
    }
}
