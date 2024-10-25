using NUnit.Framework;
using NntpAndUnitProject;

namespace NunitTests
{
    [TestFixture]
    public class TestNntpClientService
    {
        private NntpClientService _nntpClient;

        [SetUp]
        public void SetUp()
        {
            _nntpClient = new NntpClientService();
        }

        [Test]
        public void TestConnection_Success()
        {
            var connection = new ConnectionModel("news.sunsite.dk", 119, "username", "password");

            var result = _nntpClient.Connect(connection);

            Assert.IsTrue(result);  
        }

        [Test]
        public void TestSendCommand_Success()
        {
            var connection = new ConnectionModel("news.sunsite.dk", 119, "username", "password");
            _nntpClient.Connect(connection);

            var response = _nntpClient.SendCommand("LIST NEWSGROUPS");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Contains("comp")); 
        }
    }
}