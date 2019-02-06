namespace LoanManagement.Controllers
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Web.Http;

    [RoutePrefix("api/Loan")]
    public class LoanController : ApiController
    {
        [Route("GetLoans")]
        public object GetLoans()
        {
            return LoadJson("~/json/loans.json");
        }
        private object LoadJson(string path)
        {
            string json = "";
            using (StreamReader r = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(path)))
            {
                json = r.ReadToEnd();

            }
            return JsonConvert.DeserializeObject(json);
        }

    }
}
