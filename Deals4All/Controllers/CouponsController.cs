using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Deals4All.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
//using MVCEmail.Models;
using System.Net.Mail;

namespace Deals4All.Controllers
{
    public class CouponsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Customizations customclass = new Customizations();

        // GET: Coupons
        public ActionResult Index()
        {
            return View(db.Coupons.ToList());
        }

        // GET: Coupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // GET: Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouponMasterID,CouponName,CouponDescription,MerchantID,StartDate,EndDate,Status,CommissionType,CommissionValue,Pref1,Pref2,Pref3,Pref4,Pref5")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                db.Coupons.Add(coupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coupon);
        }

        // GET: Coupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CouponMasterID,CouponName,CouponDescription,MerchantID,StartDate,EndDate,Status,CommissionType,CommissionValue,Pref1,Pref2,Pref3,Pref4,Pref5")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coupon);
        }

        // GET: Coupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
            db.Coupons.Remove(coupon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Coupons/Publish/5
        [Authorize]
        public ActionResult Publish()
        {
            
            return View();
        }


        // GET: Coupons/Redeem
        [Authorize]
        public ActionResult Redeem()
        {
            
            return View();
        }


        //// GET: Coupons/Redeem
        //[HttpPost]
        //[Authorize]
        //public ActionResult Redeem([Bind(Include = "CouponCode,MerchantID,CustomerEmail,OrderTotal")] Coupon coupon)
        //{
        //    customclass.RedeemCoupon(coupon.CouponName, coupon.MerchantID, CustomerEmail, OrderTotal, Result);
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redeem(FormCollection FC)
        {
            Session["ReturnMessage"] = string.Empty;
            string retMsg = string.Empty;
            if (FC != null)
            {
                customclass.RedeemCoupon(Convert.ToString(FC["CouponCode"]), Convert.ToInt32(FC["MerchantID"]), Convert.ToString(FC["CustomerEmail"])
                    , Convert.ToString(FC["OrderTotal"]), ref retMsg);
                Session["ReturnMessage"] = retMsg;
            }
            return View();
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(EmailFormModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
        //        message.From = new MailAddress("sender@outlook.com");  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "user@outlook.com",  // replace with valid value
        //                Password = "password"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp-mail.outlook.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            await smtp.SendMailAsync(message);
        //            return RedirectToAction("Sent");
        //        }
        //    }
        //    return View(model);
        //}




    }
}
