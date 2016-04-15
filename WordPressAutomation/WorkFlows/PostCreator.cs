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

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }

            return s.ToString();
        }

        private static string[] Words = new[]
            {
                "test1", "test2", "Test3333"
            };

        private static string[] Articles = new[]
            {
                "revolving wheel", "Warmart", "community of hope"
            };

        private static string CreateTitle()
    {
        return CreateRandomString() + ", title";
    }

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void CleanUp()
        {
            if (CreatedAPost)
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
