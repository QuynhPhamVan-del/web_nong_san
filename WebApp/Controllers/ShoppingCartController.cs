using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        Dbcontext _db = new Dbcontext();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //phuong thuc add item vao gio hang
        public JsonResult AddtoCart(int id)
        {
            var dem = 0;
            var pro = _db.SanPham.FirstOrDefault(s => s.Id == id);
            if (pro != null)
            {
                GetCart().Add(pro);
                Cart cart = Session["Cart"] as Cart;
              dem = cart.Items.Count();
            }
            var check = (string)Session["check"] ?? "";
            return Json(new { status = true, message = "Thêm giỏ hàng thành công",dem=dem }, JsonRequestBehavior.AllowGet);
        }
        //trang gio hang
        public ActionResult ShowToCart()
        {
            ViewData["thongtin"] = _db.ThongTin.ToList();
            if (Session["Cart"] == null)
            {

                return RedirectToAction("Index", "Home");

            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult ThanhToan()
        {
            ViewData["thongtin"] = _db.ThongTin.ToList();
            if (Session["Cart"] == null)
            {

                return RedirectToAction("Index", "Home");

            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //public JsonResult Update_soluong(FormCollection form, int? ID_GioHang = 0)
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    int id_pro = int.Parse(form["ID_SP"]);
        //    int Sluong = int.Parse(form["So_luong"]);
        //    var tk = Convert.ToInt32(Request.Cookies["myCookie"].Value);
        //    var list = _db.GIOHANGs.Where(g => g.ID_SP == id_pro && g.ID_TK == tk && g.TinhTrang == 0 && g.ID_GioHang == ID_GioHang).ToList();
        //    foreach (var item in list)
        //    {
        //            item.SoLuong = Sluong;
        //            _db.SaveChanges();
        //    }
        //    cart.UpdateSoluong(id_pro, Sluong);
        //    return Json(new { status = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        //}
        ////checkout
        //public ActionResult CheckOut()
        //{
        //    var tk = Convert.ToInt32(Request.Cookies["myCookie"].Value);
        //    var m = Session["check"].ToString();
        //    var l = m.Trim(',').Split(',').ToList();
        //    var List = _db.GIOHANGs.Where(g => g.TinhTrang == 0 && g.ID_TK == tk && l.Contains(g.ID_GioHang.ToString())).ToList();
        //    Session["tt"] = List;
        //    ViewBag.TK = _db.TAIKHOANs.FirstOrDefault(g => g.ID_TK == tk);

        //    foreach (var item in List)
        //    {
        //        item.TinhTrang = 1;
        //        _db.SaveChanges();
        //    }
        //    if (Session["Cart"] == null)
        //    {

        //        return RedirectToAction("CheckOut", "ShoppingCart");

        //    }
        //    Cart cart = Session["Cart"] as Cart;
        //    return View(cart);
        //}
        [HttpPost]
        public JsonResult DatHang()
        {
            var user = Session["user"] as ThongTin;
            Cart cart = Session["Cart"] as Cart;
            var list = cart.Items;
            double tong = 0;
            foreach ( var item in list )
            {
                tong += Convert.ToDouble(item.product.GiaTien * (100 - item.product.GiamGia)*item.Quantity / 100);
            }
            DonHang dh=new DonHang();
            dh.SDT = user.SDT;
            dh.NgayDatHang = DateTime.Now;
            dh.DiaChiGiao = user.DiaChi;
            dh.TongTien =Convert.ToDouble(tong);
            dh.TinhTrang = 1;
            dh.IdKH = user.IdTK;
            _db.DonHang.Add(dh);
            _db.SaveChanges();
            foreach (var item in list)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.IdDH = dh.Id;
                ct.IdSP = item.product.Id;
                ct.SoLuongMua = item.Quantity;
                ct.IdCuaHang = item.product.IdTK;
                ct.GiaTien= item.product.GiaTien*(100-item.product.GiamGia)/100;
                _db.ChiTietDonHang.Add(ct);
                _db.SaveChanges();
                SanPham sp = _db.SanPham.Find(item.product.Id);
                sp.SoLuongBan += ct.SoLuongMua;
                _db.SanPham.AddOrUpdate(sp);
                _db.SaveChanges();
            }
            Session["Cart"] = null;
            return Json(new { status = true, message = "Thêm giỏ hàng thành công" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HuyDon(int Id)
        {
            var m = _db.DonHang.FirstOrDefault(g => g.Id == Id);
            m.TinhTrang = 0;
            _db.DonHang.AddOrUpdate(m);
            _db.SaveChanges();
            return RedirectToAction("QuanLyDonHang", "Home");
        }
        public ActionResult XacNhanDonHang(int Id)
        {
            var m = _db.DonHang.FirstOrDefault(g => g.Id == Id);
            m.TinhTrang = 2;
            _db.DonHang.AddOrUpdate(m);
            _db.SaveChanges();
            return RedirectToAction("QuanLyDonHang", "Home");
        }
    }
}