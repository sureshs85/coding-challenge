namespace LoanManagement.Data.Repository.Interface
{
    using Model;
    using System.Collections.Generic;

    public interface ILoanRepository
    {
        IEnumerable<LoanModel> GetAll();
        LoanModel Get(int id);
    }
}
