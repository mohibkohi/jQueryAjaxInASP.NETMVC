using jQueryAjaxInASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryAjaxInASP.NETMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllPeople());
        }

        IEnumerable<Person> GetAllPeople()
        {
            using (DBModel db = new DBModel())
            {
                return db.People.ToList<Person>();
            }

        }
        public ActionResult AddOrEdit(int id = 0)
        {
            Person per = new Person();
            /*
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    per = db.People.Where(x => x.PersonID == id).FirstOrDefault<Person>();
                }
            }*/
            return View(per);
        }
        
        [HttpPost]
        public ActionResult AddOrEdit(Person emp)
        {
            /*
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (DBModel db = new DBModel())
                {
                    if (emp.PersonID == 0)
                    {
                        db.People.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }*/
            if (emp.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                string extension = Path.GetExtension(emp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                emp.ImagePath = "~/AppFiles/Images/" + fileName;
                emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
            }
            using (DBModel db = new DBModel())
            {
                
                db.People.Add(emp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}