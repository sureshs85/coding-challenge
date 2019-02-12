namespace LoanManagement.Controllers
{
    using LoanManagement.Services;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class LoanController : ApiController
    {
        private readonly LoanService _service = new LoanService();

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetAll());
        }
    }
}
