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

            Assert.AreEqual("news.sunsite.dk", _viewModel.Server);
            Assert.AreEqual(119, _viewModel.Port);
            Assert.AreEqual("janand02@easv365.dk", _viewModel.Username);
            Assert.AreEqual("2dfd02", _viewModel.Password);
        }

        [Test]
        public void TestConnectToServer_Success()
        {

            _viewModel.ConnectToServer();

            Assert.IsTrue(_viewModel._isAuthenticated);
        }

        [Test]
        public void TestGetNewsgroups_Success()
        {

            _viewModel._isAuthenticated = true;

            _viewModel.GetNewsgroups();

            Assert.IsNotEmpty(_viewModel.UserGroups);
        }
    }
}