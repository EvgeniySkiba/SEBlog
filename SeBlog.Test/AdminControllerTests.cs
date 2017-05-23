using NUnit.Framework;
using Rhino.Mocks;
using SeBlog.Web.Controllers;
using SeBlog.Web.Models;
using SeBlog.Web.Providers;

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeBlog.Test
{
    [TestFixture]
    class AdminControllerTests
    {
        private AdminController _adminController;
        private IAuthProvider _authProvider;

        [SetUp]
        public void SetUp()
        {
            _authProvider = MockRepository.GenerateMock<IAuthProvider>();
            _adminController = new AdminController(_authProvider);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            _adminController.Url = new UrlHelper(new RequestContext(httpContextMock, new RouteData()));
        }

        [Test]
        public void Login_IsLoggedIn_True_Test()
        {
            // arrange
            _authProvider.Stub(s => s.IsLoggedIn).Return(true);

            // act
            var actual = _adminController.Login("/admin/manage");

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/admin/manage", ((RedirectResult)actual).Url);
        }

        [Test]
        public void Login_Post_Model_Invalid_Test()
        {
            // arrange
            // arrange
            var model = new LoginModel
            {
                UserName = "invaliduser",
                Password = "password"
            };
            _authProvider.Stub(s => s.Login(model.UserName, model.Password))
                         .Return(false);

            // act
            var actual = _adminController.Login(model, "/");

            // assert
            Assert.IsInstanceOf<ViewResult>(actual);
            var modelStateErrors = _adminController.ModelState[""].Errors;
            Assert.IsTrue(modelStateErrors.Count > 0);
            Assert.AreEqual("The user name or password provided is incorrect.",
                modelStateErrors[0].ErrorMessage);
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [Test]
        public void Login_Post_User_Valid_Test()
        {
            // arrange
            var model = new LoginModel
            {
                UserName = "validuser",
                Password = "password"
            };
            _authProvider.Stub(s => s.Login(model.UserName, model.Password))
                         .Return(true);

            // act
            var actual = _adminController.Login(model, "/");

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/", ((RedirectResult)actual).Url);
        }
    }
}
