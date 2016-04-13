using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressTests.Posts_Tests
{
    [TestClass]
    public class AllPostsTests : WordpressTests
    {
        //Added posts show up in all posts
        //Can trash a post - udalo sia zalatwic przy okazji pierwszego testu
        //Can search posts

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            //Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            //Add a new post
            PostCreator.CreatePost();

            //zbedny kod, jesli mamy kreatora postow
            //NewPostPage.GoTo();
            //NewPostPage.CreatePost("Added post show up, title").WithBody("Added post show up, body").Publish();

            //Go to posts, get the new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");//sprawdza czy nastapil przyrost liczby postow po dodaniu nowego

            //Check for added posts

            //z kreatorem postow bedzie to wygladalo inaczej
            //Assert.IsTrue(ListPostsPage.DoesAPostExistWithTitle("Added post show up, title"));

            Assert.IsTrue(ListPostsPage.DoesAPostExistWithTitle(PostCreator.PreviousBody));


            //Trash post (clean up)
            //z kreatorem postow bedzie to wygladalo inaczej
            //ListPostsPage.TrashPost("Added post show up, title");
           
            ListPostsPage.TrashPost(PostCreator.PreviousBody);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");//sprawdza czy post dodany w tescie zostal automatycznie usuniety
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            //Create a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Searching posts, title").WithBody("Searching posts, body").Publish();

            //Go to list posts
            ListPostsPage.GoTo(PostType.Posts);

            //Search for the post
            ListPostsPage.SearchForPost("Searching posts, title");//jedyna metoda do zaimplementowania na tym etapie, wszystkie pozostale sa juz zaimplementowane

            //Chect that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesAPostExistWithTitle("Searching posts, title"));

            //Clean up (Trash post)
            ListPostsPage.TrashPost("Searching posts, title");
        }
    }
}
