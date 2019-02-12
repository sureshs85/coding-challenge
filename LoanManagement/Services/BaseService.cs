using System.Collections.Generic;

namespace LoanManagement.Services
{
    public abstract class BaseService<T> where T : class
    {
        public abstract IEnumerable<T> GetAll();
        public abstract T Get(int id);
    }
}