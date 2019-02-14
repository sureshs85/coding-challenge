namespace LoanManagement.Tests.Data.Repository
{
    using LoanManagement.Data.Model;
    using LoanManagement.Data.Repository.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class FakeLoanRepository : ILoanRepository
    {
        private static readonly IEnumerable<LoanModel> _loans = new List<LoanModel>() {
                new LoanModel { Id = 1, LoanName = "Loan 1" },
                new LoanModel { Id = 2, LoanName = "Loan 2" },
                new LoanModel { Id = 3, LoanName = "Loan 3" }
            };
        public LoanModel Get(int id)
        {
            return _loans.FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<LoanModel> GetAll()
        {
            return _loans;
        }
    }
}
