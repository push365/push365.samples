using Push365.Samples.API.Messages.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Push365.Samples.API.Controllers
{
    public class IntegrationController : ApiController
    {
        [HttpPost]
        [Route("your-custom-route-without-parameters")]
        public HttpResponseMessage YourEndpoint(Push365IntegrationRequest request)
        {
            /*
             * TODO:
             * Implement your custom business process
             */

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
