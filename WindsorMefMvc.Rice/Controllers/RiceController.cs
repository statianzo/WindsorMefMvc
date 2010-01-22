using System.Web.Mvc;

namespace WindsorMefMvc.Rice.Controllers
{
	public class RiceController:Controller
	{
		public ActionResult Index()
		{
			return new ContentResult();
		}
	}
}