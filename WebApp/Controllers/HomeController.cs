using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Dbcontext db = new Dbcontext();
        public ActionResult Index()
        {
            ViewData["banner"] = db.Banner.Where(g => g.IsDelete == false).OrderByDescending(g => g.ThuTu).ToList();
            ViewData["sanpham"] = db.SanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            ViewData["loai"] = db.LoaiSanPham.ToList();
            return View();
        }

        public ActionResult Menu()
        {
            ViewData["menu"] = db.LoaiSanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return PartialView();
        }
        public ActionResult Login()
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        public ActionResult ThongTinCaNhan()
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        public ActionResult SanPham(int? page)
        {
            var tk = Session["TaiKhoan"] as TaiKhoan;
            var list = db.SanPham.Where(g=>g.IdTK==tk.Id).ToList();
            if (page == null) page = 1;
            var books = list.OrderBy(g => g.NgayDang);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.pageNumber = page;
            ViewBag.total = list.ToList().Count();
            return View(books.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemMoi()
        {
            ViewData["loai"] = db.LoaiSanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi([Bind(Include = "Id,TenSP,GiaTien,MoTa,IdTK,HSD,GiamGia,IdLoai")] SanPham sanpham, HttpPostedFileBase HinhAnh)
        {
            ViewData["loai"] = db.LoaiSanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            try
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/SanPham"), fileName);
                    HinhAnh.SaveAs(path);
                    sanpham.HinhAnh = fileName;
                }
                sanpham.NgayDang = DateTime.Now;
                sanpham.TinhTrang = true;
                sanpham.SoLuongBan = 0;
                db.SanPham.Add(sanpham);
                db.SaveChanges();
                Session["user"] = db.ThongTin.FirstOrDefault(g => g.Id == sanpham.Id);
                return RedirectToAction("SanPham", "Home", new { sc = 2 });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Sua(int Id)
        {
            ViewData["sp"] = db.SanPham.Find(Id);
            ViewData["loai"] = db.LoaiSanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Sua([Bind(Include = "Id,TenSP,GiaTien,MoTa,IdTK,HSD,GiamGia,IdLoai")] SanPham sanpham, HttpPostedFileBase HinhAnh)
        {
            ViewData["loai"] = db.LoaiSanPham.ToList();
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            try
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/SanPham"), fileName);
                    HinhAnh.SaveAs(path);
                    sanpham.HinhAnh = fileName;
                }
                sanpham.NgayDang = DateTime.Now;
                sanpham.TinhTrang = true;
                sanpham.SoLuongBan = 0;
                db.SanPham.AddOrUpdate(sanpham);
                db.SaveChanges();
                Session["user"] = db.ThongTin.FirstOrDefault(g => g.Id == sanpham.Id);
                return RedirectToAction("SanPham", "Home", new { sc = 1 });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult SuaThongTin()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaThongTin([Bind(Include = "Id,HoTen,SDT,Email,DiaChi,CMND,IdDiaPhuong,NgaySinh,GioiTinh,IdTK ,Avatar,GioiThieu ")] ThongTin sanpham, HttpPostedFileBase Avatar)
        {
            try
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/User"), fileName);
                    Avatar.SaveAs(path);
                    sanpham.Avatar = fileName;
                }
                db.ThongTin.AddOrUpdate(sanpham);
                db.SaveChanges();
                Session["user"] = db.ThongTin.FirstOrDefault(g => g.Id == sanpham.Id);
                return RedirectToAction("TrangBanHang", "Home", new { sc = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("SuaThongTin", "Home", new { sc = 1 });
            }
        }
        public ActionResult TrangBanHang()
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThongTinCaNhan([Bind(Include = "Id,HoTen,SDT,Email,DiaChi,CMND,IdDiaPhuong,NgaySinh,GioiTinh,IdTK ,Avatar ")] ThongTin sanpham, HttpPostedFileBase Avatar)
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();

            try
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/User"), fileName);
                    Avatar.SaveAs(path);
                    sanpham.Avatar = fileName;
                }
                db.ThongTin.AddOrUpdate(sanpham);
                db.SaveChanges();
                Session["user"]=db.ThongTin.FirstOrDefault(g=>g.Id==sanpham.Id);
                return RedirectToAction("Index", "Home", new { sc = 3 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ThongTinCaNhan", "Home", new { sc = 1 });
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new {sc=2});
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Login([Bind(Include = "TenDangNhap,MatKhau")] TaiKhoan sanpham)
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();

            try
            {
                var check=db.TaiKhoan.FirstOrDefault(g=>g.TenDangNhap==sanpham.TenDangNhap&&g.MatKhau==sanpham.MatKhau);
                if (check == null)
                {
                    ViewBag.thongbao = "Tài khoản mật khẩu không chính xác";
                    return View();
                }
                Session["user"] = db.ThongTin.FirstOrDefault(g => g.IdTK == check.Id);
                Session["TaiKhoan"] = check;
                return RedirectToAction("Index", "Home", new { sc = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home", new { sc = 1 });
            }
        }
        public ActionResult SignIn()
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SignIn([Bind(Include = "Id,HoTen,SDT,Email,DiaChi,CMND,IdDiaPhuong,NgaySinh,GioiTinh")] ThongTin sanpham, HttpPostedFileBase Avatar,string TenDangNhap, string Matkhau,string NhapLai)
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();

            try
            {
                if (Matkhau.Length < 8)
                {
                    ViewBag.thongbao = "Mật khẩu chứa ít nhất 8 kí tự.";
                    return View();
                }
                if(Matkhau != NhapLai)
                {
                    ViewBag.thongbao = "Mật khẩu không trùng khớp.";
                    return View();
                }
                TaiKhoan tk = new TaiKhoan();
                tk.TenDangNhap= TenDangNhap;
                tk.MatKhau= Matkhau;
                tk.PhanQuyen = 2;
                db.TaiKhoan.Add( tk );
                db.SaveChanges();
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/User"), fileName);
                    Avatar.SaveAs(path);
                    sanpham.Avatar =  fileName;
                }
                sanpham.IdTK = tk.Id;
                sanpham.GioiThieu = null;
                db.ThongTin.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Login", "Home", new { sc = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("SignIn", "Home", new { sc = 1 });
            }
        }
        public JsonResult XoaSP(int Id)
        {
            try
            {
                SanPham sp = db.SanPham.Find(Id);
                db.SanPham.Remove(sp);
                db.SaveChanges();
                return Json(new { status = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = true, message = "Lỗi dữ liệu" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DanhSachSanPham(int? page,int IdDiaPhuong=0,int IdLoai=0,int IdLoc=0)
        {
            ViewData["diaphuong"] = db.DiaPhuong.ToList();
            ViewData["loai"] = db.LoaiSanPham.ToList();
            var list = db.SanPham.Where(g => g.TinhTrang == true).ToList();
            ViewBag.IdDiaPhuong = IdDiaPhuong;
            ViewBag.IdLoai = IdLoai;
            ViewBag.IdLoc = IdLoc;
            if (IdDiaPhuong > 0)
            {
                list=list.Where(g=>g.IdDiaPhuong==IdDiaPhuong).ToList();
            }
            if(IdLoai > 0)
            {
                list = list.Where(g => g.IdLoai == IdLoai).ToList();
            }
            var books = list.OrderByDescending(g => g.NgayDang);
            if (IdLoc == 1)
            {
                books = books.OrderBy(g => g.TenSP);
            }
            if (IdLoc == 2)
            {
                books = books.OrderBy(g => g.GiaTien);
            }
            if (IdLoc == 3)
            {
                books = books.OrderByDescending(g => g.GiaTien);
            }
            if (IdLoc == 4)
            {
                books = books.OrderBy(g => g.NgayDang);
            }
            if (page == null) page = 1;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            ViewBag.pageNumber = page;
            ViewBag.total = list.ToList().Count();
            return View(books.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChitietSanPham(int? Id)
        {
            ViewData["thongtin"] = db.ThongTin.ToList();
            var chitiet = db.SanPham.Find(Id);
            ViewData["sanpham"] = db.SanPham.Where(g => g.IdDiaPhuong == chitiet.IdDiaPhuong).ToList();

            return View(chitiet);
        }

        public ActionResult QuanLyDonHang(int? page)
        {
            var user = Session["user"] as ThongTin ;
            var listCT = db.ChiTietDonHang.Where(g => g.IdCuaHang == user.IdTK).ToList();
            ViewData["ct"] = listCT;
            ViewData["sp"] = db.SanPham.ToList();
            var lstDH = listCT.Select(g =>(int?)g.IdDH).ToList();
            var list = db.DonHang.Where(g => lstDH.Contains(g.Id)).ToList();
            if (page == null) page = 1;
            var books = list.OrderBy(g => g.NgayDatHang);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.pageNumber = page;
            ViewBag.total = list.ToList().Count();
            return View(books.ToPagedList(pageNumber, pageSize));
        }
    }
}