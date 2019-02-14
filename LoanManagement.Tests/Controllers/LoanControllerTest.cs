namespace LoanManagement.Tests.Controllers
{
    using LoanManagement.Controllers;
    using LoanManagement.Data.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using Tests.Data.Repository;

    [TestClass]
    public class LoanControllerTest
    {
        [TestMethod]
        public void Get()
        {
            LoanController controller = new LoanController(new FakeLoanRepository())
            {
                Request = new HttpRequestMessage()
            };
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage result = controller.Get();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetAllFromRepo()
        {
            FakeLoanRepository repo = new FakeLoanRepository();
            IEnumerable<LoanModel> loans = repo.GetAll();

            Assert.IsNotNull(loans);
        }
        [TestMethod]
        public void GetByIdFromRepo()
        {
            FakeLoanRepository repo = new FakeLoanRepository();
            LoanModel loan = repo.Get(1);
            Assert.IsNotNull(loan);
        }
        [TestMethod]
        public void GetByIdFromRepoNegative()
        {
            FakeLoanRepository repo = new FakeLoanRepository();
            LoanModel loan = repo.Get(4);
            Assert.IsNull(loan);
        }
    }
}
