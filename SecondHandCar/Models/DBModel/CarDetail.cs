namespace SecondHandCar.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarDetail
    {
        [Key]
        public Guid CarId { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }

        public int CarGrade { get; set; }

        public int YearsUsed { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string SaleLocation { get; set; }

        [Required]
        [StringLength(50)]
        public string CarColour { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] CarImage { get; set; }

        public DateTime DateUploaded { get; set; }

        public int CustId { get; set; }

        public virtual UserTable UserTable { get; set; }
    }
}
