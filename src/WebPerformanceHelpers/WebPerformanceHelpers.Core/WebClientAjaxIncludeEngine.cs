using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebPerformanceHelpers.Core
{
    public class WebClientAjaxIncludeEngine : AjaxIncludeEngineBase, IAjaxIncludeRequestEngine
    {
        public string ExecuteRequest(AjaxIncludeProxyRequest request, ControllerContext context)
        {
            if (request == null || !request.RequestsList.Any())
                return null;

            var httpRequest = context.RequestContext.HttpContext.Request;

            if (httpRequest == null)
                return null;

            var host = httpRequest.GetAbsoluteHost();
            var webClient = new WebClient();

            var response = string.Empty;

            foreach (var requestUrl in request.RequestsList)
            {
                var uri = new Uri(host, requestUrl);

                var requestResponse = webClient.DownloadString(uri);

                response += request.Wrap ? WrapInTag(requestResponse, requestUrl) : requestResponse;
            }

            return response;
        }
    }
}