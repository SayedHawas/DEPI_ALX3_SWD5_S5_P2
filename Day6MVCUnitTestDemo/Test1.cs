using Microsoft.AspNetCore.Mvc;
using MVCDemoLab.Controllers;

namespace Day6MVCUnitTestDemo
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            TestController controller = new TestController();
            //Act
            double result = controller.div(100, 5);
            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestView()
        {
            //Arrange
            TestController controller = new TestController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Welcome in Test With MVC ", result.ViewData["Title"]);
        }
    }
}
