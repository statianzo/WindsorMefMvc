using System.Web.Mvc;

namespace WindsorMefMvc.Home.Controllers
{
	public class HomeController:Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}