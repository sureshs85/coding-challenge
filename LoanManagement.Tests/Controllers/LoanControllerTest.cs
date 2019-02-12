using LoanManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanManagement.Tests.Controllers
{
    [TestClass]
    public class LoanControllerTest
    {
        [TestMethod]
        public void Get()
        {
            LoanController controller = new LoanController();
            System.Net.Http.HttpResponseMessage result = controller.Get();
            Assert.IsNotNull(result);
        }

    }
}
