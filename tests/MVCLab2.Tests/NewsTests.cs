using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCLab2.Models;
using Xunit;

namespace MVCLab2.Tests
{
    public class NewsTests
    {
        [Fact]
        public void TestTitle()
        {
            const string TITLE = "Good morning!";
            var n = new NewsList();
            n.Title = TITLE;
            Assert.Equal(TITLE, n.Title);
        }

        [Fact]
        public void TestDate()
        {
            DateTime date = DateTime.Now;
            var n = new NewsList();
            n.Date = date;
            Assert.Equal(date, n.Date);
        }

        [Fact]
        public void TestStory()
        {
            const string STORY = "Very interesting story.";
            var n = new NewsList();
            n.Story = STORY;
            Assert.Equal(STORY, n.Story);
        }

        //Could not think of another good test so I just did this
        [Fact]
        public void TestNewsListList()
        {
            var news = new List<NewsList>();

            news.Add(new NewsList
            {
                Date = DateTime.Now,
                Title = "Lorem ipsum dolor sit amet",
                Story = "Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            });

            news.Add(new NewsList
            {
                Date = DateTime.Now,
                Title = "Sed ut perspiciatis unde omnis",
                Story = "Iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt."
            });

            Assert.Equal(news.Count, 2);
        }
    }
}
