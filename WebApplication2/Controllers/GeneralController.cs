using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class GeneralController : Controller
    {
        // GET: General
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList() {
            using (var db = new ChallengeEntities()) {
                db.Configuration.LazyLoadingEnabled = false;
                var context = (from up in db.UserProjects
                               join u in db.User on up.UserId equals u.Id
                               join p in db.Project on up.ProjectId equals p.Id
                               select new
                               {
                                   ProjectId = up.ProjectId,
                                   StartDate = p.StartDate.ToString(),
                                   TimeToStart = DbFunctions.DiffDays(p.EndDate, p.StartDate) > 0 ? DbFunctions.DiffDays(p.EndDate, p.StartDate).ToString() : "Started" ,
                                   EndDate = p.EndDate.ToString(),
                                   Credits = p.Credits,
                                   Status = up.IsActive

                               }).ToList();
                return Json(new { data = context}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}