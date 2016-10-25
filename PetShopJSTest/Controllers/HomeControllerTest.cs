using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShopJS.Controllers;

namespace PetShopJSTest.Controllers {
    [TestClass()]
    public class HomeControllerTest {
        [TestMethod()]
        public void IndexTest() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AboutTest() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod()]
        public void ContactTest() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

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