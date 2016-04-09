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
        [TestMethod]
        public static void Added_Posts_Show_Up()
        {
            //Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            //Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added post show up, title").WithBody("Added post show up, body").Publish();

            //Go to posts, get the new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");//sprawdza czy nastapil przyrost liczby postow po dodaniu nowego

            //Check for added posts
            Assert.IsTrue(ListPostsPage.DoesAPostExistWithTitle("Added post show up, title"));

            //Trash post (clean up)
            ListPostsPage.TrashPost("Added post show up, title");
            Assert.AreEqual(ListPostsPage PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");//sprawdza czy post dodany w tescie zostal automatycznie usuniety
        }
    }
}
