using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordPressAutomation
{
    public class PostCreator
    {

        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();//tworzy radnom title
            PreviousBody = CreateBody();//trorzy random body

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();//tworzy posta z randon danymi
        }

        public static string PreviousBody { get; set; }
        public static string PreviousTitle { get; set; }

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void CleanUp()
        {
            if (CretedAPost)
            {
                TrashPost();
            }
        }

        private static void TrashPost()
        {
            ListPostsPage.TrashPost(PreviousTitle);
            Initialize();//aby upewnic sie, ze zmienna PreviousTitle napewno bedzie miala wartosc null
        }

        protected static bool CreatedAPost
        {
            get { return !String.IsNullOrEmpty(PreviousTitle);}
        }
    }
}
