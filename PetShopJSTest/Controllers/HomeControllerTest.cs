using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetShopJS.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetShopJSTest.Controllers {
    [TestClass()]
    public class HomeControllerTest {
        [TestMethod()]
        public void IndexTest() {
            using (new FakeHttpContext.FakeHttpContext()) {
                // Arrange
                HomeController controller = new HomeController();

                var server = new Mock<HttpServerUtilityBase>();
                server.Setup(s => s.MapPath("~/images/slider/")).Returns("c:\\temp\\");

                var httpContext = new Mock<HttpContextBase>();

                httpContext.Setup(x => x.Server).Returns(server.Object);

                controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

                // Act
                ViewResult result = controller.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
        }

        [TestMethod()]
        public void AboutTest() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.Message);
        }

        [TestMethod()]
        public async Task ContactTest() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = await controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Chart1Test() {

        }

        [TestMethod()]
        public void SendEmailTest() {

        }
    }
}