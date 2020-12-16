using RateABusiness.Models;
using RateABusiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateABusiness.Controllers
{
    public class HomeController : Controller
    {
        private RatingsAppKleinEntities3 objRatingsAppKleinEntities3;

        public HomeController()
        {
            objRatingsAppKleinEntities3 = new RatingsAppKleinEntities3();
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<BusinessViewModel> ListOfBusinessViewModels = (from objBusiness in objRatingsAppKleinEntities3.Businesses
                                                                       select new BusinessViewModel()
                                                                       {
                                                                           Name = objBusiness.Name,
                                                                           Address = objBusiness.Address,
                                                                           City = objBusiness.City,
                                                                           State = objBusiness.State,
                                                                           Zip = (int)objBusiness.Zip,
                                                                           Type = objBusiness.Type


                                                                       }
                                                                       ).ToList();
            return View(ListOfBusinessViewModels);
        }
        public ActionResult ShowReview(int businessId)
        {
            IEnumerable<ReviewViewModel> listOfReviewViewModels = (from objComment in objRatingsAppKleinEntities3.Reviews
                                                                   where objComment.BusinessId == businessId
                                                                   select new ReviewViewModel()
                                                                   {
                                                                       BusinessId = (int)objComment.BusinessId,
                                                                       Comment = objComment.Comment,
                                                                       ReviewId = objComment.ReviewId,
                                                                       ReviewDate = (DateTime)objComment.ReviewDate,
                                                                       Rating = (int)objComment.Rating

                                                                   }
                                                                    ).ToList();
            ViewBag.BusinessId = businessId;

            return View(listOfReviewViewModels);
        }

        public ActionResult AddComment(int businessId, int rating, string reviewComment)
        {
            Review objReview = new Review();
            objReview.BusinessId = businessId;
            objReview.Comment = reviewComment;
            objReview.ReviewDate = DateTime.Now;
            objReview.Rating = rating;
            //objReview.GuestId = Guid.NewGuid();
            objRatingsAppKleinEntities3.Reviews.Add(objReview);
            objRatingsAppKleinEntities3.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}