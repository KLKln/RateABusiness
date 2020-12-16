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
                Guest objGuest = new Guest
                {
                    Email = objUserModel.Email,
                    Password = objUserModel.Password
                };
                objRatingsAppKleinEntities4.Guests.Add(objGuest);
                objRatingsAppKleinEntities4.SaveChanges();
                objUserModel.AccountCreationMessage = "User Created Successfully";
                return View("Register");
            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
    }
}