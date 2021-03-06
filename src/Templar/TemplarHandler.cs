﻿using System.Web;
using System.Web.Routing;

namespace Templar
{
    /// <summary>
    /// Used when optimization is turn off.
    /// </summary>
    public class TemplarHandler : IRouteHandler, IHttpHandler
    {
        private readonly IContentSource source;

        public TemplarHandler(IContentSource source)
        {
            this.source = Ensure.NotNull(source, "source");
        }

        public bool IsReusable { get { return false; } }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        public void ProcessRequest(HttpContext context)
        {
            Ensure.NotNull(context, "context");

            string content = source.GetContent(new HttpContextWrapper(context));

            context.Response.ContentType = "text/javascript";
            context.Response.Write(content);
        }
    }
}