using ServerUsage.EF;
using ServerUsage.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ServerUsage.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var model = new IndexViewModel();
			using (var db = new ApplicationDbContext())
			{
				model.ServersHistory = db.ServerHistories.ToList();
			}
			GetTotalUsageTime(model);
			return View(model);
		}

		public ActionResult Add()
		{
			using (var db = new ApplicationDbContext())
			{
				var server = new ServerHistory
				{
					CreateDateTime = DateTime.Now
				};
				db.ServerHistories.Add(server);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public JsonResult Remove(int[] serverIds)
		{
			using (var db = new ApplicationDbContext())
			{
				foreach (var id in serverIds)
				{
					var server = db.ServerHistories.Where(s => s.VirtualServerId == id).FirstOrDefault();
					server.RemoveDateTime = DateTime.Now;
				}
				db.SaveChanges();
			}
			return Json(new { }, JsonRequestBehavior.AllowGet);
		}

		private void GetTotalUsageTime(IndexViewModel model)
		{
			var diff = new TimeSpan();
			foreach (var server in model.ServersHistory)
			{
				if (server.RemoveDateTime.HasValue)
				{
					diff += server.RemoveDateTime.Value - server.CreateDateTime;
				}
				else
				{
					diff += model.CurrentDateTime - server.CreateDateTime;
				}
			}
			model.TotalUsageTime = diff.ToString(@"hh\:mm\:ss");
		}
	}
}