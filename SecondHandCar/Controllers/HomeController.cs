using SecondHandCar.Models.DBModel;
using SecondHandCar.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondHandCar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Car(UploadDetails uploadDetails)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                var photo = Request.Files[0];
                using (var photoStream = new MemoryStream())
                {
                    try
                    {
                        photo.InputStream.CopyTo(photoStream);
                        byte[] photoData = photoStream.ToArray();
                        var db = new CarSaleDb();
                        CarDetail carDetail = new CarDetail();
                        //UserTable user = new UserTable();
                       
                        carDetail.Amount= uploadDetails.Amount;
                        carDetail.CarGrade= uploadDetails.CarGrade;
                        carDetail.CarColour = uploadDetails.CarColour;
                        carDetail.CarModel= uploadDetails.CarModel;
                        carDetail.YearsUsed = uploadDetails.YearsUsed;
                        carDetail.SaleLocation= uploadDetails.SaleLocation;
                        carDetail.DateUploaded = DateTime.UtcNow.AddHours(1);
                        carDetail.CustId = uploadDetails.CustId;
                        carDetail.CarId=Guid.NewGuid();
                        carDetail.CarImage = photoData;
                        carDetail.UserTable = (from u in db.UserTables
                                               where u.CustId == uploadDetails.CustId
                                               select u).FirstOrDefault();
                        db.CarDetails.Add(carDetail);
                        db.SaveChanges();

                        ViewBag.ErrorMessage = "Your Car has been put up for sale successfully!!!";
                        return View();
                    }
                    catch (Exception ex)
                    {

                        ViewBag.ErrorMessage = "Check your input values again";
                        return View();
                    }

                }
                    
            }
            else
            {
                ViewBag.ErrorMessage = "Upload a valid image file!!!";

                return View();
            }
        }
        public ActionResult Car()
        {
            ViewBag.Message = "Upload Car Details";

            return View();
        }
    }
}