namespace LoanManagement.Controllers
{
    using Data.Repository.Interface;
    using LoanManagement.Data.Model;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class LoanController : ApiController
    {
        private ILoanRepository _repo;
        public LoanController(ILoanRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Get all Loans
        /// </summary>
        /// <returns>List of Loans</returns>
        public HttpResponseMessage Get()
        {
            IEnumerable<LoanModel> result = null;
            try
            {
                result = _repo.GetAll();
            }
            catch (Exception)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Something went wrong, please contact administrator."),
                    ReasonPhrase = "Internal Server Error"
                };
                throw new HttpResponseException(response);
            }

            if (result == null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No Loans found"),
                    ReasonPhrase = "Loans Not Found"
                };
                throw new HttpResponseException(response);
            }
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAll());
        }
    }
}
