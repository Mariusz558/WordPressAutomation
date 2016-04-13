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
    }
}
