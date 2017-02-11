using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCLab2.Models;
using Xunit;
using MVCLab2.Models.Repositories;
using MVCLab2.Controllers;

namespace MVCLab2.Tests
{
    public class RepositoryTests
    {
        [Fact]
        void TestMemberRetrieve()
        {
            FakeMemberRepository repository = new FakeMemberRepository();
            HomeController controller = new HomeController(repository);

            List<Member> members = controller.Members().ViewData.Model as List<Member>;

            Assert.Equal(repository.GetMembers()[0].UserName, members[0].UserName);
            Assert.Equal(repository.GetMembers()[0].DisplayName, members[0].DisplayName);
            Assert.Equal(repository.GetMembers()[0].Email, members[0].Email);
        }

        //Will try to think of a different method to test
        [Fact]
        void TestMemberSet()
        {
            FakeMemberRepository repository = new FakeMemberRepository();
            HomeController controller = new HomeController(repository);

            List<Member> members = controller.Members().ViewData.Model as List<Member>;

            members[0].DisplayName = "Fig";

            Assert.NotEqual(repository.GetMembers()[0].DisplayName, members[0].DisplayName);
        }

        [Fact]
        void TestMessageRetrieve()
        {
            FakeMessageRepository repository = new FakeMessageRepository();
            MessagesController controller = new MessagesController(repository);

            List<Message> messages = controller.Messages().ViewData.Model as List<Message>;

            Assert.Equal(repository.GetMessages()[0].UserName, messages[0].UserName);
            Assert.Equal(repository.GetMessages()[0].Topic, messages[0].Topic);
            Assert.Equal(repository.GetMessages()[0].Body, messages[0].Body);
            Assert.Equal(repository.GetMessages()[0].Title, messages[0].Title);
        }

        //Will try to think of a different kind of method to test here too
        [Fact]
        void TestMessageSet()
        {
            FakeMessageRepository repository = new FakeMessageRepository();
            MessagesController controller = new MessagesController(repository);

            List<Message> messages = controller.Messages().ViewData.Model as List<Message>;

            messages[0].Body = "Oops I wrote the wrong thing!";

            Assert.NotEqual(repository.GetMessages()[0].Body, messages[0].Body);
        }
    }
}
