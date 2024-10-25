using NntpAndUnitProject;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace NunitTests
{
    [TestFixture]
    public class TestMainViewModel
    {
        private MainViewModel _viewModel;

        [SetUp]
        public void SetUp()
        {
            _viewModel = new MainViewModel();
        }

        [Test]
        public void TestConnectionModelInitialization()
        {
            // Test if connection model initializes correctly
            Assert.AreEqual("news.sunsite.dk", _viewModel.Server);
            Assert.AreEqual(119, _viewModel.Port);
            Assert.AreEqual("janand02@easv365.dk", _viewModel.Username);
            Assert.AreEqual("2dfd02", _viewModel.Password);
        }

        [Test]
        public void TestConnectToServer_Success()
        {
            // Simulate successful connection
            _viewModel.ConnectToServer();
            // Assert that the _isAuthenticated flag is true after connection
            Assert.IsTrue(_viewModel._isAuthenticated);
        }

        [Test]
        public void TestGetNewsgroups_Success()
        {
            // Assume we are already authenticated
            _viewModel._isAuthenticated = true;

            // Execute GetNewsgroups method
            _viewModel.GetNewsgroups();

            // Check if newsgroups were added to the collection
            Assert.IsNotEmpty(_viewModel.UserGroups);
        }
    }
}