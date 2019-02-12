namespace LoanManagement.Services
{
    using LoanManagement.Data.Model;
    using LoanManagement.Data.Repository;
    using System.Collections.Generic;

    public class LoanService : BaseService<LoanModel>
    {
        private readonly LoanRepository _repo = new LoanRepository();

        public override LoanModel Get(int id)
        {
            return _repo.Get(id);
        }

        public override IEnumerable<LoanModel> GetAll()
        {
            return _repo.GetAll();
        }
    }
}