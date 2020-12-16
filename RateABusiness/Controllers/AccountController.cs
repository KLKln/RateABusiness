using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateABusiness.ViewModel;
using RateABusiness.Models;
using System.Data.Entity.Infrastructure;

namespace RateABusiness.Controllers
{
    public class AccountController : Controller
    {

        RatingsAppKleinEntities4 objRatingsAppKleinEntities4 = new RatingsAppKleinEntities4();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();        
            return View(objUserModel);
        }

        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if(ModelState.IsValid)
            {
                Guest objGuest = new Guest()
                
                {                    
                    Email = objUserModel.Email,
                    Password = objUserModel.Password
                };
            
                objRatingsAppKleinEntities4.Guests.Add(objGuest);
                _ = objRatingsAppKleinEntities4.SaveChanges();
                objUserModel.AccountCreationMessage = "User Created Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objRatingsAppKleinEntities4.Guests.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Email and/or Password are not correct");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}