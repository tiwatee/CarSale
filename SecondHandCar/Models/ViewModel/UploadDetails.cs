using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondHandCar.Models.ViewModel
{
    public class UploadDetails
    {
        public string CarModel { get; set; }
        public int CarGrade { get; set; }

        public int YearsUsed { get; set; }

        public decimal Amount { get; set; }

        public string SaleLocation { get; set; }

        public string CarColour { get; set; }
        public int CustId { get; set; }

        //public byte[] CarImage { get; set; }

        //public DateTime DateUploaded { get; set; }

    }
}