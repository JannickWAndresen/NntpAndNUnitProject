using NUnit.Framework;
using NntpAndUnitProject;

namespace NunitTests
{
    [TestFixture]
    public class TestConnectionModel
    {
        [Test]
        public void TestConnectionModel_Initialization()
        {
            var connection = new ConnectionModel("news.example.com", 119, "user", "password");

            Assert.AreEqual("news.example.com", connection.Server);
            Assert.AreEqual(119, connection.Port);
            Assert.AreEqual("user", connection.Username);
            Assert.AreEqual("password", connection.Password);
        }
    }
}