using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WindsorMefMvc.Web
{
	public class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string originalPath = Request.Path;
			HttpContext.Current.RewritePath(Request.ApplicationPath, false);
			IHttpHandler httpHandler = new MvcHttpHandler();
			httpHandler.ProcessRequest(HttpContext.Current);
			HttpContext.Current.RewritePath(originalPath, false);
		}
	}
}