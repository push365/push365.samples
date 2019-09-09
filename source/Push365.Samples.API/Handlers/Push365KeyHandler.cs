using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Push365.Samples.API.Handlers
{
    public class Push365KeyHandler : DelegatingHandler
    {
        readonly string _push365Header = "X-Push365-WebHook-ApplicationId";
        readonly string _organizationApplicationId = "{REPLACE-YOUR-ORGANIZATION-APPLICATION-ID-HERE}";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isValid = false;
            IEnumerable<string> headerList;

            var isExists = request.Headers.TryGetValues(_push365Header, out headerList);

            if (isExists)
            {
                if (headerList.FirstOrDefault().Equals(_organizationApplicationId))
                {
                    isValid = true;
                }
            }

            if (!isValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.Forbidden, "Bad Application Identity");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}