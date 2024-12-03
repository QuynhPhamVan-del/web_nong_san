using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        // GET: Admin/Banner
        Dbcontext db = new Dbcontext();
        public ActionResult Index(int? page)
        {
            var list = db.Banner.ToList();
            if (page == null) page = 1;
            var books = list.OrderBy(g => g.ThuTu);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.pageNumber = page;
            ViewBag.total = list.ToList().Count();
            return View(books.ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create([Bind(Include = "Id,TenBanner,Thutu")] Banner sanpham,HttpPostedFileBase HinhAnh)
        {
            try
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/Banner"), fileName);
                    HinhAnh.SaveAs(path);
                    sanpham.Link = "../Upload/Banner/" + fileName;
                }
                db.Banner.Add(sanpham);
                db.SaveChanges();
                return Json(new { status = true, message = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = true, message = "Lỗi dữ liệu" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}